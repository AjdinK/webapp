using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.GetAll
{
    [Route ("FAQ")]
    public class FAQGetAllEndpoint : MyBaseEndpoint<NoRequest, FAQGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FAQGetAllEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("GetAll")]
        public override async Task <FAQGetAllResponse> Obradi ([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.FAQ
                .OrderBy(f => f.ID)
                .Select(f => new FAQGetAllResponseFAQ(f.ID, f.Pitanje, f.Odgovor))
                .ToListAsync(cancellationToken: cancellationToken);

            return new FAQGetAllResponse (data);
        }
    }
}
