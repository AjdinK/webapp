using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.GetAll
{
    public class FAQGetAllEndpoint : MyBaseEndpoint<NoRequest, FAQGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FAQGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("FAQ/GetAll")]
        public override async Task<FAQGetAllResponse> Obradi(
            [FromQuery] NoRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = await _applicationDbContext
                .FAQ.OrderBy(f => f.ID)
                .Select(f => new FAQGetAllResponseFAQ
                {
                    ID = f.ID,
                    Pitanje = f.Pitanje,
                    Odgovor = f.Odgovor,
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return new FAQGetAllResponse { FAQLista = data };
        }
    }
}
