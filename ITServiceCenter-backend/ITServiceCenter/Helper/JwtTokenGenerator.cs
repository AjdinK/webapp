using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using itservicecenter.Entities.Models;
using Microsoft.IdentityModel.Tokens;

namespace itservicecenter.Helper
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(KorisnickiNalog korisnik, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.ASCII.GetBytes(key);


            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, korisnik.ID.ToString()),
                new(ClaimTypes.Name, korisnik.Username)
            };

            if (korisnik.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            if (korisnik.IsServiser)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Serviser"));
            }

            if (korisnik.IsProdavac)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Prodavac"));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}