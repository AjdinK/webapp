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
                Serviser.Passweord = "test";
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

            if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
            {
                byte[]? SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

                if (SlikaBajtovi == null)
                    throw new Exception("pogresan base64 format");

                byte[]? SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
                if (SlikaBajtoviVelika == null)
                    throw new Exception("pogresan format slike");

                var folderPath = "slike-serviser";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                Serviser.SlikaKorisnikaVelika = $"{folderPath}-{Serviser.Username.ToLower()}-velika.jpg";
                await System.IO.File.WriteAllBytesAsync(
                    Serviser.SlikaKorisnikaVelika,
                    SlikaBajtoviVelika,
                    cancellationToken
                );
            }

            await _applicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
            return Serviser.ID;
        }
    }
}
