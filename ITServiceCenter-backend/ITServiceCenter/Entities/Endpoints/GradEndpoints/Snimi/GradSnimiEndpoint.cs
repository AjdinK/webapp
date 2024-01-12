using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Dodaj
{
    public class GradSnimiEndpoint : MyBaseEndpoint <GradSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GradSnimiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }
        [HttpPost("Grad/Snimi")]
        public override async Task <int> Obradi ([FromBody] GradSnimiRequest request, CancellationToken cancellationToken)
        {
           Models.Grad? Grad;
            if (request.ID == 0)
            {
                Grad = new Models.Grad();
                _applicationDbContext.Add(Grad);
            }
            else {
                Grad = _applicationDbContext.Grad.FirstOrDefault(g => g.ID == request.ID);
            }

            Grad.Naziv = request.Naziv; 
            await _applicationDbContext.SaveChangesAsync (cancellationToken : cancellationToken);
            return Grad.ID;
        }
    }
}
