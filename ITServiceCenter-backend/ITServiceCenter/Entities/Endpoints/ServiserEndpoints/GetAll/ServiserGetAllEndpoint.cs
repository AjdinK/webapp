using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.GetAll
{
    public class ServiserGetAllEndpoint : MyBaseEndpoint<NoRequest, ServiserGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ServiserGetAllEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet ("Serviser/GetAll")]
        public override async Task <ServiserGetAllResponse> Obradi([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Serviser
            .OrderBy( s => s.ID)
            .Where( s => !s.JelObrisan)
            .Select ( s => new ServiserGetAllResponseServiser{
                ID = s.ID,
                Ime = s.Ime,
                Prezime = s.Prezime,
                Username = s.Username,
                Email = s.Email,
                GradID = s.GradID,
                SpolID = s.SpolID,
                IsServiser = s.IsServiser,
                SlikaKorisnikaNovaString = s.SlikaKorisnikaTrenutnoBajt.ToBase64()
            })
            .ToListAsync(cancellationToken : cancellationToken);

            return new ServiserGetAllResponse {
                ListaServiser = data
            };
        }
    }
}
