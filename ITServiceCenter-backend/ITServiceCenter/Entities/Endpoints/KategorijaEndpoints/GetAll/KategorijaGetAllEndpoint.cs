using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.GetAll;

public class KategorijaGetAllEndpoint : MyBaseEndpoint<NoRequest, KategorijaGetAllResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public KategorijaGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpGet("kategorija/getall")]
    public override async Task<KategorijaGetAllResponse> Obradi(
        [FromQuery] NoRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = await _applicationDbContext
            .Kategorija.OrderBy(k => k.ID)
            .Select(k => new KategorijaGetAllResponseKategorija { ID = k.ID, Naziv = k.Naziv })
            .ToListAsync(cancellationToken);

        return new KategorijaGetAllResponse { Kategorije = data };
    }
}