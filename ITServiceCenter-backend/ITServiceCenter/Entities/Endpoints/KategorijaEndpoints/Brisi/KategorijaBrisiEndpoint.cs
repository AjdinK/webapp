using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.Brisi;

public class KategorijaBrisiEndpoint : MyBaseEndpoint<KategorijaBrisiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KategorijaBrisiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpDelete("kategorija/brisi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromQuery] KategorijaBrisiRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = _applicationDbContext.Kategorija.FirstOrDefault(k => k.ID == request.ID);
        if (data != null)
        {
            _applicationDbContext.Kategorija.Remove(data);
            await _applicationDbContext.SaveChangesAsync();
            return request.ID;
        }

        throw new UserException("Error -> Pogresen ID");
    }
}