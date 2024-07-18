using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints;

[ApiController]
[Route("[controller]")]
public class AuthLoginEndpoint : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly string _jwtKey;

    public AuthLoginEndpoint(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _jwtKey = configuration["Jwt:Key"];
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
    {
        if (string.IsNullOrEmpty(request.KorisnickoIme) || string.IsNullOrEmpty(request.Lozinka))
            return BadRequest("Korisnicko Ime i lozinka su obavezni");

        var korisnik = await _context.KorisnickiNalog.FirstOrDefaultAsync(x => x.Username == request.KorisnickoIme);

        if (korisnik == null) return BadRequest("Nevazeci podaci za prijavu");

        var hash = PasswordGenerator.GenerateHash(korisnik.LozinkaSalt, request.Lozinka);

        if (hash != korisnik.LozinkaHash)
            return Unauthorized("Nevazeci podaci za prijavu -> korisnicko ime ili lozinka");

        var jwtToken = JwtTokenGenerator.GenerateToken(korisnik, _jwtKey);

        var noviToken = new AutenfitikacijaToken
        {
            IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            Vrijednost = jwtToken,
            KorisnickiNalog = korisnik,
            VrijemeEvidentiranja = DateTime.Now
        };

        _context.Add(noviToken);
        await _context.SaveChangesAsync();
        return Ok(new { Token = jwtToken });
    }
}