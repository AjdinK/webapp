using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Brisi
{
    public class VrstaDioBrisiEndpoint : MyBaseEndpoint<VrstaDioBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VrstaDioBrisiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete("VrstaDio/Brisi")]
        public override async Task<int> Obradi(
            [FromQuery] VrstaDioBrisiRequest request,
            CancellationToken cancellationToken
        )
        {
            var VrstaDio = _applicationDbContext.VrstaDio.FirstOrDefault(v => v.ID == request.ID);
            if (VrstaDio != null)
            {
                _applicationDbContext.Remove(VrstaDio);
                await _applicationDbContext.SaveChangesAsync();
                return request.ID;
            }
            else
            {
                throw new Exception("Pogresen ID");
            }
        }
    }
}
