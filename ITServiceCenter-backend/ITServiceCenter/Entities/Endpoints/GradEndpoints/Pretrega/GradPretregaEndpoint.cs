using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Pretrega;

public class GradPretregaEndpoint : MyBaseEndpoint<GradPretregaRequest, GradPretregaResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GradPretregaEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpGet("grad/pretrega")]
    public override async Task<GradPretregaResponse> Obradi(
        [FromQuery] GradPretregaRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = await _applicationDbContext
            .Grad.Where(g =>
                request.Naziv == null || g.Naziv.ToLower().Contains(request.Naziv.ToLower())
            )
            .OrderBy(g => g.ID)
            .Select(g => new GradPretregaResponseGrad { ID = g.ID, Naziv = g.Naziv })
            .ToListAsync(cancellationToken);

        return new GradPretregaResponse { Gradovi = data };
    }
}