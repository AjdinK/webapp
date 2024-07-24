using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints;

public class AuthLogoutEndpoint : MyBaseEndpoint<AuthLogoutRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("auth/logout")]
    public override async Task<NoResponse> Obradi([FromBody] AuthLogoutRequest request,
        CancellationToken cancellationToken)
    {
        var autentifikacijaToken = _applicationDbContext.AutenfitikacijaToken
            .FirstOrDefault(x => x.Vrijednost == request.Token);

        if (autentifikacijaToken == null)
            throw new NotImplementedException("Nije pronadjen token");

        _applicationDbContext.Remove(autentifikacijaToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new NoResponse();
    }
}