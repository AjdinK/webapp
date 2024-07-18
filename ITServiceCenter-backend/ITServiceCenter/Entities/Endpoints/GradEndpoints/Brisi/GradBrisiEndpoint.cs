using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Brisi;

public class GradBrisiEndpoint : MyBaseEndpoint<GradBrisiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public GradBrisiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpDelete("Grad/brisi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromQuery] GradBrisiRequest request, CancellationToken cancellationToken)
    {
        var grad = _applicationDbContext.Grad.FirstOrDefault(g => g.ID == request.ID);
        if (grad == null) throw new UserException("Error -> Pogresen ID");
        _applicationDbContext.Grad.Remove(grad);
        await _applicationDbContext.SaveChangesAsync();
        return request.ID;
    }
}