using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.Brisi;

public class ProdavacBrisiEndpoint : MyBaseEndpoint<ProdavacBrisiRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ProdavacBrisiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpDelete("prodavac/brisi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromQuery] ProdavacBrisiRequest request,
        CancellationToken cancellationToken
    )
    {
        var prodavac = _ApplicationDbContext.Prodavac.FirstOrDefault(p => p.ID == request.ID);

        if (prodavac != null)
        {
            prodavac.JelObrisan = true;
            await _ApplicationDbContext.SaveChangesAsync();
            return request.ID;
        }

        throw new UserException("Pogresen ID ");
    }
}