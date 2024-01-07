using FIT_Api_Example.Data;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Dodaj
{
    [Route ("ispit-dodaj")]
    public class PrijavaIspitaDodajEndpoints : MyBaseEndpint<PrijavaIspitaDodajRequest, PrijavaIspitaDodajResposns>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PrijavaIspitaDodajEndpoints(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost]
        public override async Task<PrijavaIspitaDodajResposns> Handle([FromBody]PrijavaIspitaDodajRequest request)
        {
            var ispit = new Data.Models.Ispit
            {
                Naziv = request.Naziv,
                DatumVrijemeIspita = request.DatumPolaganja,
                PredmetID = request.PredmetID,
                Komentar = request.Komentar
            };

            _applicationDbContext.Add(ispit);
            await _applicationDbContext.SaveChangesAsync();

            return new PrijavaIspitaDodajResposns { IspitId = ispit.ID };

        }
    }
}
