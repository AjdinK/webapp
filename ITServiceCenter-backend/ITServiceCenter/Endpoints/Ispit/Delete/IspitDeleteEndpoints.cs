using FIT_Api_Example.Data;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Delete
{
    [Route("ispit-delete")]
    public class IspitDeleteEndpoints : MyBaseEndpint<IspitDeleteRequest, IspitDeleteResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IspitDeleteEndpoints(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpDelete]
        public override async Task<IspitDeleteResponse> Handle([FromQuery]IspitDeleteRequest request)
        {
            var ispit = _applicationDbContext.Ispit.Where(x => x.ID == request.IspitID).FirstOrDefault();
            if (request == null || ispit == null)
            {
                throw new Exception("Not Found ID");
            }
            else
            {
                _applicationDbContext.Remove(ispit);
                await _applicationDbContext.SaveChangesAsync();
            }

            return new IspitDeleteResponse
            {
                poruka = "successful delete"
            };
        }
    }
}
