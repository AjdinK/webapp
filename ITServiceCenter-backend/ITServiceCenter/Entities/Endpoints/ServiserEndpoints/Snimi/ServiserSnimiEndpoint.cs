using itservicecenter.Data;
using ITServiceCenter.Entities.Endpoints.ServiserEndpoints.Snimi;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ServiserSnimiEndpoint : MyBaseEndpoint<ServiserSnimiRequest, int>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ServiserSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpPost("serviser/snimi")]
    [Authorize(Roles = "Admin")]
    public override async Task<int> Obradi(
        [FromBody] ServiserSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        var serviser = new Serviser();

        if (request.Id > 0) serviser = _ApplicationDbContext.Serviser.FirstOrDefault(a => a.ID == request.Id);

        if (serviser is null) throw new UserException("Greska, ne postoji serviser ID");

        serviser.SpolID = 1;
        serviser.Email = request.Email;
        serviser.GradID = request.GradID;
        serviser.Ime = request.Ime;
        serviser.Prezime = request.Prezime;
        serviser.Username = request.Username;
        serviser.IsServiser = request.IsServiser;

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

            var folderPath = "wwwroot/slike-serviser";
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // serviser.SlikaKorisnikaMala = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";

            serviser.SlikaKorisnikaVelika = $"{folderPath}/{serviser.Username}-velika.jpg";
            await System.IO.File.WriteAllBytesAsync(
                serviser.SlikaKorisnikaVelika,
                SlikaBajtoviVelika,
                cancellationToken
            );

            // await System.IO.File.WriteAllBytesAsync(serviser.SlikaKorisnikaMala, SlikaBajtoviMala,
            //     cancellationToken);
        }

        await _ApplicationDbContext.SaveChangesAsync(cancellationToken);
        return serviser.ID;
    }
}