using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints;

[Route("[controller]")]
public class AuthLogoutEndpoint : MyBaseEndpoint<NoRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost]
    public override async Task<NoResponse> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
    {
        var autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

        if (autentifikacijaToken == null)
            return new NoResponse();

        _applicationDbContext.Remove(autentifikacijaToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new NoResponse();
    }
}