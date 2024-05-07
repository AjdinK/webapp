using System.IO.Compression;
using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Identity;
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
        public override async Task<int> Obradi([FromBody] ServiserSnimiRequest request,
            CancellationToken cancellationToken)
        {
            Serviser? Serviser;
            if (request.ID == 0)
            {
                Serviser = new Serviser();
                _applicationDbContext.Add(Serviser);

                Serviser.Username = request.Username;
                Serviser.Email = request.Email;
                Serviser.Passweord = "test";
                Serviser.SlikaKorisnikaTrenutnoBajt = Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
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

            if (!string.IsNullOrEmpty(request.SlikaKorisnikaNovaString))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaNovaString?.ParsirajBase64();

                if (SlikaBajtovi == null) throw new Exception("format slike nije base64");

                byte[]? SlikaBajtoviResizedVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 75);
                byte[]? SlikaBajtoviResizedMala = ImageHelper.ResizeSlike(SlikaBajtovi, 50, 75);
                Serviser.SlikaKorisnikaTrenutnoBajt = SlikaBajtoviResizedVelika;

                //Opcija za snimanje u File System
                if (SlikaBajtoviResizedVelika != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Serviser.Username} +_velika" + ".png");

                if (SlikaBajtoviResizedMala != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Serviser.Username} +_mala" + ".png");
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
            return Serviser.ID;
        }
    }
}