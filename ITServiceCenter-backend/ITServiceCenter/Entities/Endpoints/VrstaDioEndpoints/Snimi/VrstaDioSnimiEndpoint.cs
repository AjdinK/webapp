using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Snimi;

public class VrstaDioSnimiEndpoint : MyBaseEndpoint<VrstaDioSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public VrstaDioSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpPost("vrstadio/snimi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromBody] VrstaDioSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        VrstaDio? VrstaDio;
        if (request.ID == 0)
        {
            VrstaDio = new VrstaDio();
            _applicationDbContext.Add(VrstaDio);
        }
        else
        {
            VrstaDio = _applicationDbContext.VrstaDio.FirstOrDefault(v => v.ID == request.ID);
        }

        VrstaDio.Naziv = request.Naziv;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return VrstaDio.ID;
    }
}