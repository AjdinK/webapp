using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.GetByID
{
    public class VrstaDioGetByIDEndpoint : MyBaseEndpoint<VrstaDioGetByRequest, VrstaDioGetByResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public VrstaDioGetByIDEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet ("VrstaDio/GetByID")]
        public override Task <VrstaDioGetByResponse> Obradi ([FromQuery] VrstaDioGetByRequest request, CancellationToken cancellationToken)
        {
            var data = _applicationDbContext.VrstaDio
                .OrderBy (v => v.ID)
                .Select (v=> new VrstaDioGetByResponse { 
                    ID = v.ID,
                    Naziv = v.Naziv,
                })
                .SingleAsync (v=> v.ID == request.ID, cancellationToken);
            return data;
        }
    }
}
