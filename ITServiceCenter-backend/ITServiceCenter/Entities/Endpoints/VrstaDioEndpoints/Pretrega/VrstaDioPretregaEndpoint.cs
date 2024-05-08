using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Pretrega
{
    public class VrstaDioPretregaEndpoint
        : MyBaseEndpoint<VrstaDioPretregaRequest, VrstaDioPretregaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VrstaDioPretregaEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("VrstaDio/Pretrega")]
        public override async Task<VrstaDioPretregaResponse> Obradi(
            [FromQuery] VrstaDioPretregaRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = await _applicationDbContext
                .VrstaDio.Where(v =>
                    request.Naziv == null || v.Naziv.ToLower().Contains(request.Naziv.ToLower())
                )
                .OrderBy(v => v.ID)
                .Select(v => new VrstaDioPretregaResponseVrstaDio { ID = v.ID, Naziv = v.Naziv, })
                .ToListAsync(cancellationToken: cancellationToken);

            return new VrstaDioPretregaResponse { ListaVrstaDio = data };
        }
    }
}
