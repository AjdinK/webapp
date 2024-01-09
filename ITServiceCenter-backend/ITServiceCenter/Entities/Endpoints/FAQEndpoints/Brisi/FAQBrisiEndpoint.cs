using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.Brisi
{
    [Route("FAQ")]
    public class FAQBrisiEndpoint : MyBaseEndpoint<FAQBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FAQBrisiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete ("Brisi")]
        public override async Task <int> Obradi ([FromBody] FAQBrisiRequest request, CancellationToken cancellationToken)
        {

            var FAQ = _applicationDbContext.FAQ.FirstOrDefault(f => f.ID == request.ID);
            if (FAQ != null)
            {
                _applicationDbContext.FAQ.Remove(FAQ);
                await _applicationDbContext.SaveChangesAsync();
                return request.ID;
            }
            else {
                throw new Exception("Error -> Pogresen ID");
            }
        }
    }
}
