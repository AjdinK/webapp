using itservicecenter.Data;
using itservicecenter.Entities.Endpoints.ServiserEndpoints.Dodaj;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.ProdavacEndpoints.Dodaj;

public class ProdavacDodajEndpoint : MyBaseEndpoint<ProdavacDodajRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ProdavacDodajEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpPost("prodavac/dodaj")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(ProdavacDodajRequest request, CancellationToken cancellationToken)
    {
        Prodavac? prodavac;

        if (request.ID == 0)
        {
            prodavac = new Prodavac();
            _ApplicationDbContext.Add(prodavac);
        }
        else
        {
            throw new Exception("prodavac ID mora biti nula kada se dodaje novi u bazi");
        }

        prodavac.Ime = request.Ime;
        prodavac.Prezime = request.Prezime;
        prodavac.IsProdavac = request.IsProdavac;
        prodavac.GradID = request.GradID;
        prodavac.SpolID = request.SpolID;
        prodavac.Username = request.Username;
        prodavac.Email = request.Email;
        prodavac.LozinkaSalt = PasswordGenerator.GenerateSalt();
        prodavac.LozinkaHash = PasswordGenerator.GenerateHash(prodavac.LozinkaSalt, request.Lozinka);


        if (!string.IsNullOrEmpty(request.SlikaKorisnikaBase64))
        {
            var SlikaBajtovi = request.SlikaKorisnikaBase64?.ParsirajBase64();

            if (SlikaBajtovi == null) throw new UserException("pogresan base64 format");

            var SlikaBajtoviVelika = ImageHelper.ResizeSlike(SlikaBajtovi, 200, 80);
            if (SlikaBajtoviVelika == null) throw new UserException("pogresan format slike");

            var folderPath = "wwwroot/slike-prodavac";
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            prodavac.SlikaKorisnikaVelika = $"{folderPath}/{prodavac.Username.ToLower()}-velika.jpg";
            await System.IO.File.WriteAllBytesAsync(
                prodavac.SlikaKorisnikaVelika,
                SlikaBajtoviVelika,
                cancellationToken
            );
        }

        await _ApplicationDbContext.SaveChangesAsync(cancellationToken);
        return prodavac.ID;
    }
}