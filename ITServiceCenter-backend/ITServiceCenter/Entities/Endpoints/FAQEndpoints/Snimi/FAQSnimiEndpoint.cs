using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.FAQEndpoints.Snimi;

public class FAQSnimiEndpoint : MyBaseEndpoint<FAQSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public FAQSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpPost("faq/snimi")]
    public override async Task<int> Obradi(
        [FromBody] FAQSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        FAQ? fAQ;

        if (request.ID == 0)
        {
            fAQ = new FAQ();
            _applicationDbContext.Add(fAQ);
        }
        else
        {
            fAQ = _applicationDbContext.FAQ.FirstOrDefault(f => f.ID == request.ID);
        }

        fAQ.Pitanje = request.Pitanje;
        fAQ.Odgovor = request.Odgovor;
        await _applicationDbContext.SaveChangesAsync();
        return fAQ.ID;
    }
}