using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System.Text.Json.Serialization;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints.Snimi
{
    public class AdminSnimiEndpoint : MyBaseEndpoint<AdminSnimiRequest, int>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public AdminSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Admin/Snimi")]
        public override async Task<int> Obradi([FromBody] AdminSnimiRequest request,
            CancellationToken cancellationToken)
        {
            Models.Admin? Admin;

            if (request.Id == 0)
            {
                Admin = new Admin();
                Admin.Passweord = "test";
                Admin.Email = "test@test.com";
            }
            else
            {
                Admin = _ApplicationDbContext.Admin.FirstOrDefault(a => a.ID == request.Id);
            }

            Admin.SpolID = 1;
            Admin.Email = request.Email;
            Admin.GradID = request.GradId;
            Admin.Ime = request.Ime;
            Admin.Prezime = request.Prezime;
            Admin.Username = request.Username;
            Admin.IsProdavac = request.IsProdavac;
            Admin.IsServiser = request.IsServiser;
            Admin.IsAdmin = request.IsAdmin;


            if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

                if (SlikaBajtovi == null)
                    throw new Exception("pogresan base64 format");

                byte[]? SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
                if (SlikaBajtoviVelika == null)
                    throw new Exception("pogresan format slike");

                byte[]? SlikaBajtoviMala = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
                if (SlikaBajtoviMala == null)
                    throw new Exception("pogresan format slike");

                var folderPath = "slike-admin";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                Admin.SlikaKorisnika = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";
                Admin.SlikaKorisnikaMala = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";

                // Admin.SlikaKorisnikaVelika = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";
                // await System.IO.File.WriteAllBytesAsync(Admin.SlikaKorisnikaMala, SlikaBajtoviVelika,
                //     cancellationToken);

                await System.IO.File.WriteAllBytesAsync(Admin.SlikaKorisnikaVelika, SlikaBajtoviMala,
                    cancellationToken);
            }

            await _ApplicationDbContext.SaveChangesAsync();
            return Admin.ID;
        }
    }
}