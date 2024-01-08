using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Pretrega
{
    [Route("Grad")]
    public class GradPretregaEndpoint : MyBaseEndpoint<GradPretregaRequest, GradPretregaResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public GradPretregaEndpoint(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        [HttpGet ("Pretrega")]
        public override async Task<GradPretregaResponse> Obradi ([FromQuery] GradPretregaRequest request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Grad
                .Where(g => request.Naziv == null || g.Naziv.Contains(request.Naziv))
                .OrderBy(g => g.ID)
                .Select(g => new GradPretregaResponseGrad
                {
                    ID = g.ID,
                    Naziv = g.Naziv,
                }).ToListAsync(cancellationToken: cancellationToken);

            return new GradPretregaResponse
            {
                Gradovi = data
            };
        }
    }
}
