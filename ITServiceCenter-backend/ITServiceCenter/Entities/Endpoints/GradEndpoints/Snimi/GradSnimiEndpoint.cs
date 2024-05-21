using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Dodaj
{
    public class GradSnimiEndpoint : MyBaseEndpoint<GradSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GradSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Grad/Snimi")]
        [Authorize(Roles = "Admin")]
        public override async Task<int> Obradi(
            [FromBody] GradSnimiRequest request,
            CancellationToken cancellationToken
        )
        {
            Grad? Grad;
            if (request.ID == 0)
            {
                Grad = new Grad();
                _applicationDbContext.Add(Grad);
            }
            else
            {
                Grad = _applicationDbContext.Grad.FirstOrDefault(g => g.ID == request.ID);
            }

            Grad.Naziv = request.Naziv;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Grad.ID;
        }
    }
}