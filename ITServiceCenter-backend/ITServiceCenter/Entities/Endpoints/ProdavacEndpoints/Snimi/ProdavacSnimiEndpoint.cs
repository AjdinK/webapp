using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.Snimi;

public class ProdavacSnimiEndpoint : MyBaseEndpoint<ProdavacSnimiRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ProdavacSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpPost("prodavac/snimi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromBody] ProdavacSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        var prodavac = new Prodavac();

        if (request.ID > 0) prodavac = _ApplicationDbContext.Prodavac.FirstOrDefault(a => a.ID == request.ID);

        if (prodavac is null) throw new UserException("Greska, ne postoji serviser ID");

        prodavac.Ime = request.Ime;
        prodavac.Prezime = request.Prezime;
        prodavac.IsProdavac = request.IsProdavac;
        prodavac.GradID = request.GradID;
        prodavac.SpolID = request.SpolID;
        prodavac.Email = request.Email;
        prodavac.Username = request.Username;

        if (request.Lozinka != null)
        {
            prodavac.LozinkaSalt = PasswordGenerator.GenerateSalt();
            prodavac.LozinkaHash = PasswordGenerator.GenerateHash(prodavac.LozinkaSalt, request.Lozinka);
        }


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