using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetByID
{
    [Route("Grad")]
    public class GradGetByIDEndpoint : MyBaseEndpoint<GradGetByIDRequest, GradGetByIDResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        public GradGetByIDEndpoint (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet ("GetByID")]
        public override async Task<GradGetByIDResponse> Obradi ([FromQuery] GradGetByIDRequest request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Grad
                .OrderBy(g => g.ID)
                .Select(g => new GradGetByIDResponse
                {
                    ID = g .ID,
                    Naziv = g .Naziv,   
                }).SingleAsync(g => g.ID == request.IDGrad , cancellationToken : cancellationToken);

            return data;
        }
    }
}
