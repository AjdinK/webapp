using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.Brisi
{
    public class FAQBrisiEndpoint : MyBaseEndpoint<FAQBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FAQBrisiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete("FAQ/brisi")]
        [Authorize(Roles = "Admin")]
        public override async Task<int> Obradi(
            [FromQuery] FAQBrisiRequest request,
            CancellationToken cancellationToken
        )
        {
            var FAQ = _applicationDbContext.FAQ.FirstOrDefault(f => f.ID == request.ID);
            if (FAQ != null)
            {
                _applicationDbContext.FAQ.Remove(FAQ);
                await _applicationDbContext.SaveChangesAsync();
                return request.ID;
            }

            throw new Exception("Error -> Pogresen ID");
        }
    }
}