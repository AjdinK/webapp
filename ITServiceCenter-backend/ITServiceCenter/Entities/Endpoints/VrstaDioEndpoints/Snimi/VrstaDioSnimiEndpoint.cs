using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Snimi
{
    public class VrstaDioSnimiEndpoint : MyBaseEndpoint<VrstaDioSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public VrstaDioSnimiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost ("VrstaDio/Snimi")]
        public override async Task <int> Obradi ([FromBody] VrstaDioSnimiRequest request, CancellationToken cancellationToken)
        {
            Models.VrstaDio? VrstaDio;
            if (request.ID == 0)
            {
                VrstaDio = new Models.VrstaDio();
                _applicationDbContext.Add(VrstaDio);
            }
            else {
                VrstaDio = _applicationDbContext.VrstaDio.FirstOrDefault(v => v.ID == request.ID);
            }

            VrstaDio.Naziv = request.Naziv;
            await _applicationDbContext.SaveChangesAsync (cancellationToken: cancellationToken);
            return VrstaDio.ID;
        }
    }
}
