using FIT_Api_Example.Data;
using FIT_Api_Example.Endpoints.Ispit.Delete;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Update
{
    [Microsoft.AspNetCore.Mvc.Route("ispit-update")]
    public class IspitUpdateEndpoints : MyBaseEndpint<IspitUpdateRequest, IspitUpdateRespons>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IspitUpdateEndpoints(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut]
        public override async Task<IspitUpdateRespons> Handle([FromQuery]IspitUpdateRequest request)
        {
            var ispit = _applicationDbContext.Ispit.Where(x => x.ID == request.IspitID).FirstOrDefault();
            if (request == null || ispit == null)
            {
                throw new Exception("Not Found ID");
            }
            else
            {
                ispit.DatumVrijemeIspita = request.Datum;
                ispit.Komentar = request.Komentar;

                _applicationDbContext.Update(ispit);
               await  _applicationDbContext.SaveChangesAsync();
            }
            return new IspitUpdateRespons
            {
                IspitId= request.IspitID,
            };
        }
    }
}
