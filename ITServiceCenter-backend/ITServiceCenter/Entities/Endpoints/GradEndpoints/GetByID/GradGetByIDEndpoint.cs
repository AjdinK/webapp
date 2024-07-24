using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetByID;

public class GradGetByIDEndpoint : MyBaseEndpoint<GradGetByIDRequest, GradGetByIDResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GradGetByIDEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpGet("grad/getbyid")]
    public override async Task<GradGetByIDResponse> Obradi(
        [FromQuery] GradGetByIDRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = await _applicationDbContext
            .Grad.OrderBy(g => g.ID)
            .Select(g => new GradGetByIDResponse { ID = g.ID, Naziv = g.Naziv })
            .SingleAsync(g => g.ID == request.GradID, cancellationToken);

        return data;
    }
}