using System.IO.Compression;
using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.Snimi
{
    public class ServiserSnimiEndpoint : MyBaseEndpoint<ServiserSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ServiserSnimiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost ("Serviser/Snimi")]
        public override async Task <int> Obradi([FromBody] ServiserSnimiRequest request, CancellationToken cancellationToken)
        {
            Serviser? Serviser;
            if (request.ID == 0){
                Serviser = new Serviser ();
                _applicationDbContext.Add(Serviser);

                Serviser.Username = request.Username;
                Serviser.Email = request.Email;
                Serviser.Passweord = "test";
            }
            else {
                Serviser = _applicationDbContext.Serviser.FirstOrDefault( s => s.ID == request.ID);
            }

            Serviser!.Ime = request.Ime;
            Serviser.Prezime = request.Prezime;
            Serviser.Ime = request.Ime;
            Serviser.Email = request.Email;
            Serviser.Username = request.Username;
            Serviser.IsServiser = request.IsServiser;
            Serviser.GradID = request.GradID;
            Serviser.SpolID = request.SpolID;

            await _applicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
            return Serviser.ID;
        }
    }
}