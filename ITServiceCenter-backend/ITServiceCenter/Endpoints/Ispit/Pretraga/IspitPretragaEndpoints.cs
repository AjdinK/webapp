using FIT_Api_Example.Data;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.Ispit.Pretraga
{ 
    [Microsoft.AspNetCore.Mvc.Route("ispiti-pretraga")]
    public class IspitPretragaEndpoints: MyBaseEndpint<IspitPretragaRequest, IspitPretragaResponse>
    {
       
        private readonly ApplicationDbContext _applicationDbContext;
        public IspitPretragaEndpoints(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<IspitPretragaResponse> Handle([FromBody]IspitPretragaRequest request)
        {
            var rezltat = await _applicationDbContext.Ispit
              .Where(x => request.Naziv == null || x.Predmet.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
              .Select(x => new IspitPretragaResponseIspiti()
              {
                  IspitId = x.ID,
                  Naziv = x.Naziv,
                  DatumPolaganja = x.DatumVrijemeIspita,
                  PredmetID = x.PredmetID,
                  PuniNaziv = x.Predmet.Naziv,
                  Sifra = x.Predmet.Sifra,
                  Bodovi = x.Predmet.Ects
              }).ToListAsync();

            return new IspitPretragaResponse
            {
                IspitPretragaRespons = rezltat
            };
        }

    }
}
