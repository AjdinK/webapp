using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Brisi
{
    public class GradBrisiEndpoint : MyBaseEndpoint<GradBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GradBrisiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete("Grad/brisi")]
        public override async Task <int> Obradi ([FromBody] GradBrisiRequest request, CancellationToken cancellationToken)
        {
            var grad = _applicationDbContext.Grad.FirstOrDefault(g => g.ID == request.ID);
            if (grad != null)
            {
                _applicationDbContext.Grad.Remove(grad);
                await _applicationDbContext.SaveChangesAsync();
                return request.ID;
            }
            else {
                throw new Exception("Error -> Pogresen ID");
            }   
        }
    }
}
