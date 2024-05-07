using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.Snimi
{
    public class ProdavacSnimiEndpoint : MyBaseEndpoint<ProdavacSnimiRequest, int>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ProdavacSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Prodavac/Snimi")]
        public override async Task<int> Obradi([FromBody] ProdavacSnimiRequest request,
            CancellationToken cancellationToken)
        {
            Prodavac? Prodavac;
            if (request.ID == 0)
            {
                Prodavac = new Prodavac();
                _ApplicationDbContext.Add(Prodavac);

                Prodavac.Email = request.Email;
                Prodavac.Username = request.Username;
                Prodavac.Passweord = "test";
                Prodavac.SlikaKorisnikaTrenutnoBajt = Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
            }
            else
            {
                Prodavac = _ApplicationDbContext.Prodavac.FirstOrDefault(p => p.ID == request.ID);
            }

            Prodavac!.Ime = request.Ime;
            Prodavac.Prezime = request.Prezime;
            Prodavac.IsProdavac = request.IsProdavac;
            Prodavac.GradID = request.GradID;
            Prodavac.SpolID = request.SpolID;

            if (!string.IsNullOrEmpty(request.SlikaKorisnikaNovaString))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaNovaString?.ParsirajBase64();

                if (SlikaBajtovi == null) throw new Exception("format slike nije base64");

                byte[]? SlikaBajtoviResizedVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 75);
                byte[]? SlikaBajtoviResizedMala = ImageHelper.ResizeSlike(SlikaBajtovi, 50, 75);
                Prodavac.SlikaKorisnikaTrenutnoBajt = SlikaBajtoviResizedVelika;

                //Opcija za snimanje u File System
                if (SlikaBajtoviResizedVelika != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Prodavac.Username} +_velika" + ".png");

                if (SlikaBajtoviResizedMala != null)
                    Fajlovi.Snimi(SlikaBajtoviResizedVelika,
                        $"wwwroot/profile_images/SlikeKorisnika/{Prodavac.Username} +_mala" + ".png");
            }

            await _ApplicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
            return Prodavac.ID;
        }
    }
}