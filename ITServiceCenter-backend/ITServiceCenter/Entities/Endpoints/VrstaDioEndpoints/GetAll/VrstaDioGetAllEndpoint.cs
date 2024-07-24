using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.GetAll;

public class VrstaDioGetAllEndpoint : MyBaseEndpoint<NoRequest, VrstaDioGetAllResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public VrstaDioGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpGet("vrstadio/getall")]
    public override async Task<VrstaDioGetAllResponse> Obradi(
        [FromQuery] NoRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = await _applicationDbContext
            .VrstaDio.OrderBy(v => v.ID)
            .Select(v => new VrstaDioGetAllResponseVrstaDio { ID = v.ID, Naziv = v.Naziv })
            .ToListAsync(cancellationToken);

        return new VrstaDioGetAllResponse { ListaVrstaDio = data };
    }
}