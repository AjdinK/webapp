using FIT_Api_Example.Data;
using FIT_Api_Example.Endpoints.PrijavaIspita.Dodaj;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.PriajaIspita.Dodaj
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
            var ispit = new Data.Models.PrijavaIspita
            {
                DatumPrijave = DateTime.Now,
                IspitID = request.IspitId,
                StudentID = request.StudentId
            };

            _applicationDbContext.Add(ispit);
            await _applicationDbContext.SaveChangesAsync();

            return new PrijavaIspitaDodajResposns { IspitId = ispit.ID };

        }
    }
}
