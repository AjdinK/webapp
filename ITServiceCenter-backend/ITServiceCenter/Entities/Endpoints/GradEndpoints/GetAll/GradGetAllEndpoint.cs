using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetAll
{
    public class GradGetAllEndpoint : MyBaseEndpoint<NoRequest, GradGetAllResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public GradGetAllEndpoint (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task <GradGetAllResponse> Obradi (NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Grad
                .OrderBy(g => g.ID)
                .Select(g => new GradGetAllResponseGrad (g.ID , g.Naziv))
                .ToListAsync(cancellationToken: cancellationToken);

            return new GradGetAllResponse(data);
        }
    }
}
