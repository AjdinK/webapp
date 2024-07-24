using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.GetByID;

public class ProdavacGetByIDEndpoint
    : MyBaseEndpoint<ProdavacGetByIDRequest, ProdavacGetByIDResponse>
{
    private readonly ApplicationDbContext _ApplicationDbContext;

    public ProdavacGetByIDEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _ApplicationDbContext = ApplicationDbContext;
    }

    [HttpGet("prodavac/getbyid")]
    public override async Task<ProdavacGetByIDResponse> Obradi(
        [FromQuery] ProdavacGetByIDRequest request,
        CancellationToken cancellationToken
    )
    {
        var data = await _ApplicationDbContext
            .Prodavac.OrderBy(p => p.ID)
            .Select(p => new ProdavacGetByIDResponse
            {
                ID = p.ID,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Username = p.Username,
                IsProdavac = p.IsProdavac,
                GradID = p.GradID,
                SpolID = p.SpolID,
                Email = p.Email,
                SlikaKorisnikaBase64 = p.SlikaKorisnikaVelika
            })
            .SingleAsync(p => p.ID == request.ID, cancellationToken);

        return data;
    }
}