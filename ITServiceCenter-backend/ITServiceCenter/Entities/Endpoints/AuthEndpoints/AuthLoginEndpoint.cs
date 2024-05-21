using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints
{
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
        public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            if (string.IsNullOrEmpty(request.KorisnickoIme) || string.IsNullOrEmpty(request.Lozinka))
            {
                return BadRequest("Korisnicko Ime i lozinka su obavezni");
            }

            var korisnik = await _context.KorisnickiNalog.FirstOrDefaultAsync(x => x.Username == request.KorisnickoIme);

            if (korisnik == null)
            {
                return BadRequest("Nevazeci podaci za prijavu -> korisnicko ime ili lozinka");
            }

            var hash = PasswordGenerator.GenerateHash(korisnik.LozinkaSalt, request.Lozinka);

            if (hash != korisnik.LozinkaHash)
            {
                return Unauthorized("Nevazeci podaci za prijavu -> korisnicko ime ili lozinka");
            }

            var token = JwtTokenGenerator.GenerateToken(korisnik, _jwtKey);
            return Ok(new { Token = token });
        }
    }
}