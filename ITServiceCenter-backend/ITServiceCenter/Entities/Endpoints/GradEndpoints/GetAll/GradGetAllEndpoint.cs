using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetAll
{
    public class GradGetAllEndpoint : MyBaseEndpoint<NoRequest, GradGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GradGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Grad/GetAll")]
        public override async Task<GradGetAllResponse> Obradi(
            [FromQuery] NoRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = await _applicationDbContext
                .Grad.OrderBy(g => g.ID)
                .Select(g => new GradGetAllResponseGrad { ID = g.ID, Naziv = g.Naziv })
                .ToListAsync(cancellationToken: cancellationToken);

            return new GradGetAllResponse { Gradovi = data };
        }
    }
}
