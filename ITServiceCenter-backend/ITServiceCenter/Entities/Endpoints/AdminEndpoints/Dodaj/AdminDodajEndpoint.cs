using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints.Dodaj;

public class AdminDodajEndpoint : MyBaseEndpoint<AdminDodajRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public AdminDodajEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpPost("admin/dodaj")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi([FromBody] AdminDodajRequest request, CancellationToken cancellationToken)
    {
        Admin? admin;

        if (request.Id == 0)
        {
            admin = new Admin();
            _ApplicationDbContext.Add(admin);
        }
        else
        {
            throw new Exception("admin ID mora biti nula kada se dodaje novi admin");
        }

        admin.SpolID = 1;
        admin.Email = request.Email;
        admin.GradID = request.GradId;
        admin.Ime = request.Ime;
        admin.Prezime = request.Prezime;
        admin.Username = request.Username;
        admin.IsProdavac = true;
        admin.IsServiser = true;
        admin.IsAdmin = true;
        admin.LozinkaSalt = PasswordGenerator.GenerateSalt();
        admin.LozinkaHash = PasswordGenerator.GenerateHash(admin.LozinkaSalt, request.Lozinka);

        if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
        {
            var SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

            if (SlikaBajtovi == null) throw new UserException("pogresan base64 format");

            var SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
            if (SlikaBajtoviVelika == null) throw new UserException("pogresan format slike");

            var folderPath = "wwwroot/slike-admin";
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            admin.SlikaKorisnikaVelika = $"{folderPath}/{admin.Username}-velika.jpg";
            await System.IO.File.WriteAllBytesAsync(admin.SlikaKorisnikaVelika, SlikaBajtoviVelika,
                cancellationToken
            );
        }

        await _ApplicationDbContext.SaveChangesAsync(cancellationToken);
        return admin.ID;
    }
}