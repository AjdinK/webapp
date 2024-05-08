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
        public override async Task<int> Obradi(
            [FromBody] ProdavacSnimiRequest request,
            CancellationToken cancellationToken
        )
        {
            Prodavac? Prodavac;
            if (request.ID == 0)
            {
                Prodavac = new Prodavac();
                _ApplicationDbContext.Add(Prodavac);

                Prodavac.Email = request.Email;
                Prodavac.Username = request.Username;
                Prodavac.Passweord = "test";
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

            if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

                if (SlikaBajtovi == null)
                    throw new Exception("pogresan base64 format");

                byte[]? SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
                if (SlikaBajtoviVelika == null)
                    throw new Exception("pogresan format slike");

                var folderPath = "wwwroot/slike-prodavac";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                Prodavac.SlikaKorisnikaVelika = $"{folderPath}/{Prodavac.Username.ToLower()}-velika.jpg";
                await System.IO.File.WriteAllBytesAsync(
                    Prodavac.SlikaKorisnikaVelika,
                    SlikaBajtoviVelika,
                    cancellationToken
                );
            }

            await _ApplicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
            return Prodavac.ID;
        }
    }
}
