using System.Text.Json.Serialization;
using itservicecenter.Data;
using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Helper;

public class MyAuthService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
    {
        _applicationDbContext = applicationDbContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public bool JelLogiran()
    {
        return GetAuthInfo().isLogiran;
    }

    public MyAuthInfo GetAuthInfo()
    {
        string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["token"];

        var autentifikacijaToken = _applicationDbContext.AutenfitikacijaToken
            .Include(x => x.KorisnickiNalog)
            .SingleOrDefault(x => x.Vrijednost == authToken);
        return new MyAuthInfo(autentifikacijaToken);
    }
}

public class MyAuthInfo
{
    public MyAuthInfo(AutenfitikacijaToken? autentifikacijaToken)
    {
        this.autentifikacijaToken = autentifikacijaToken;
    }

    [JsonIgnore] public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;

    public AutenfitikacijaToken? autentifikacijaToken { get; set; }

    public bool isLogiran => korisnickiNalog != null;
}