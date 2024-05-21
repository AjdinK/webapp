using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.Snimi
{
    public class ServiserSnimiEndpoint : MyBaseEndpoint<ServiserSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ServiserSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Serviser/Snimi")]
        [Authorize(Roles = "Admin")]
        public override async Task<int> Obradi(
            [FromBody] ServiserSnimiRequest request,
            CancellationToken cancellationToken
        )
        {
            Serviser? Serviser;
            if (request.ID == 0)
            {
                Serviser = new Serviser();
                _applicationDbContext.Add(Serviser);

                Serviser.Username = request.Username;
                Serviser.Email = request.Email;
            }
            else
            {
                Serviser = _applicationDbContext.Serviser.FirstOrDefault(s => s.ID == request.ID);
            }

            Serviser!.Ime = request.Ime;
            Serviser.Prezime = request.Prezime;
            Serviser.Ime = request.Ime;
            Serviser.Email = request.Email;
            Serviser.Username = request.Username;
            Serviser.IsServiser = request.IsServiser;
            Serviser.GradID = request.GradID;
            Serviser.SpolID = request.SpolID;

            if (request.Lozinka != null)
            {
                Serviser.LozinkaSalt = PasswordGenerator.GenerateSalt();
                Serviser.LozinkaHash = PasswordGenerator.GenerateHash(Serviser.LozinkaSalt, request.Lozinka);
            }

            if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
            {
                var SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

                if (SlikaBajtovi == null)
                {
                    throw new Exception("pogresan base64 format");
                }

                var SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
                if (SlikaBajtoviVelika == null)
                {
                    throw new Exception("pogresan format slike");
                }

                var folderPath = "wwwroot/slike-serviser";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                Serviser.SlikaKorisnikaVelika = $"{folderPath}/{Serviser.Username.ToLower()}-velika.jpg";
                await System.IO.File.WriteAllBytesAsync(
                    Serviser.SlikaKorisnikaVelika,
                    SlikaBajtoviVelika,
                    cancellationToken
                );
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Serviser.ID;
        }
    }
}