using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.Snimi
{
    [Route ("FAQ")]
    public class FAQSnimiEndpoint : MyBaseEndpoint<FAQSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FAQSnimiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }
        [HttpPost ("Snimi")]
        public override async Task <int> Obradi ([FromBody] FAQSnimiRequest request, CancellationToken cancellationToken)
        {
            Models.FAQ? fAQ;

            if (request.ID == 0)
            {
                fAQ = new Models.FAQ();
                _applicationDbContext.Add(fAQ);
            }
            else {
                fAQ = _applicationDbContext.FAQ.FirstOrDefault(f => f.ID == request.ID);
                 }
            fAQ.Pitanje = request.Pitanje;
            fAQ.Odgovor = request.Odgovor;
            await _applicationDbContext.SaveChangesAsync();
           return fAQ.ID;
            }
        }
    }

