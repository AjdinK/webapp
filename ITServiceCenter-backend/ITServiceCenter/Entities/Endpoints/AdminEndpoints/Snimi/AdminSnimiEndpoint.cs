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
        public override async Task<int> Obradi([FromBody] AdminSnimiRequest request, CancellationToken cancellationToken)
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


            if (!string.IsNullOrEmpty(request.SlikaKorisnikaNovaString))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaNovaString?.ParsirajBase64();

                if (SlikaBajtovi == null )
                    throw new Exception ("format slike nije base64");

                byte[]? SlikaBajtoviResizedVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 75);
                byte[]? SlikaBajtoviResizedMala = ImageHelper.ResizeSlike(SlikaBajtovi, 50, 75);
                Admin.SlikaKorisnikaTrenutnoBajt = SlikaBajtoviResizedVelika;

                //Opcija za snimanje u File System
                if (SlikaBajtoviResizedVelika != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Admin.Username} +_velika" + ".png");

                if (SlikaBajtoviResizedMala != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Admin.Username} +_mala" + ".png");
            }

            await _ApplicationDbContext.SaveChangesAsync();
            return Admin.ID;
        }
    }
}

