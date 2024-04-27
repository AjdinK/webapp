using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.GetByID
{
    public class ProdavacGetAllEndpoint : MyBaseEndpoint<NoRequest, ProdavacGetAllResponse>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public ProdavacGetAllEndpoint (ApplicationDbContext ApplicationDbContext) {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet ("Prodavac/GetAll")]
        public override async Task <ProdavacGetAllResponse> Obradi ([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _ApplicationDbContext.Prodavac
            .OrderBy (p => p.ID)
            .Where ( p => !p.JelObrisan)
            .Select ( p => new ProdavacGetAllResponseProdavac {
                ID = p.ID,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Username = p.Username,
                IsProdavac = p.IsProdavac,
                GradID = p.GradID,
                SpolID = p.SpolID,
                Email = p.Email,
                SlikaKorisnikaNovaString = p.SlikaKorisnikaTrenutnoBajt.ToBase64()
            })
            .ToListAsync ( cancellationToken : cancellationToken);

            return new ProdavacGetAllResponse {
                ListaProdavac = data
            };
        }
    }
}