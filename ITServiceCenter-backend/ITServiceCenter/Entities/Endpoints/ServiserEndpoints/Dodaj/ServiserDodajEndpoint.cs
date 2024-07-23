using itservicecenter.Data;
using itservicecenter.Entities.Endpoints.AdminEndpoints.Dodaj;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.ServiserEndpoints.Dodaj;

public class ServiserDodajEndpoint : MyBaseEndpoint<AdminDodajRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ServiserDodajEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpPost("Serviser/Dodaj")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi([FromBody] AdminDodajRequest request, CancellationToken cancellationToken)
    {
        Serviser? serviser;

        if (request.Id == 0)
        {
            serviser = new Serviser();
            _ApplicationDbContext.Add(serviser);
        }
        else
        {
            throw new NotImplementedException("serviser ID mora biti nula kada se dodaje novi u bazi");
        }

        serviser.SpolID = 1;
        serviser.Email = request.Email;
        serviser.GradID = request.GradId;
        serviser.Ime = request.Ime;
        serviser.Prezime = request.Prezime;
        serviser.Username = request.Username;
        serviser.IsProdavac = true;
        serviser.IsServiser = true;
        serviser.IsAdmin = true;

        if (request.Lozinka != null)
        {
            serviser.LozinkaSalt = PasswordGenerator.GenerateSalt();
            serviser.LozinkaHash = PasswordGenerator.GenerateHash(serviser.LozinkaSalt, request.Lozinka);
        }

        if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
        {
            var SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

            if (SlikaBajtovi == null) throw new UserException("pogresan base64 format");

            var SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
            if (SlikaBajtoviVelika == null) throw new UserException("pogresan format slike");

            // byte[]? SlikaBajtoviMala = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
            // if (SlikaBajtoviMala == null)
            //     throw new Exception("pogresan format slike");

            var folderPath = "wwwroot/slike-admin";
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // Admin.SlikaKorisnikaMala = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";

            serviser.SlikaKorisnikaVelika = $"{folderPath}/{serviser.Username}-velika.jpg";
            await System.IO.File.WriteAllBytesAsync(
                serviser.SlikaKorisnikaVelika,
                SlikaBajtoviVelika,
                cancellationToken
            );

            // await System.IO.File.WriteAllBytesAsync(Admin.SlikaKorisnikaMala, SlikaBajtoviMala,
            //     cancellationToken);
        }

        await _ApplicationDbContext.SaveChangesAsync(cancellationToken);
        return serviser.ID;
    }
}