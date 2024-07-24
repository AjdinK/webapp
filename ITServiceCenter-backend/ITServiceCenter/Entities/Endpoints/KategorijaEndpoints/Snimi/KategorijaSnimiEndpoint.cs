using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.Snimi;

public class KategorijaSnimiEndpoint : MyBaseEndpoint<KategorijaSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KategorijaSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpPost("kategorija/snimi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromBody] KategorijaSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        Kategorija? Kategorija;
        if (request.ID == 0)
        {
            Kategorija = new Kategorija();
            _applicationDbContext.Add(Kategorija);
        }
        else
        {
            Kategorija = _applicationDbContext.Kategorija.FirstOrDefault(k =>
                k.ID == request.ID
            );
        }

        Kategorija.Naziv = request.Naziv;
        await _applicationDbContext.SaveChangesAsync();
        return Kategorija.ID;
    }
}