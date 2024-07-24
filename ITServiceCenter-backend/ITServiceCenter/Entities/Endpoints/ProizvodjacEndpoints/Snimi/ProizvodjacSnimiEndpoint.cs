using itservicecenter.Data;
using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.Snimi;

public class ProizvodjacSnimiEndpoint : MyBaseEndpoint<ProizvodjacSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProizvodjacSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
    {
        _applicationDbContext = ApplicationDbContext;
    }

    [HttpPost("proizvodjac/snimi")]
    public override async Task<int> Obradi(
        [FromBody] ProizvodjacSnimiRequest request,
        CancellationToken cancellationToken
    )
    {
        Proizvodjac? Proizvodjac;
        if (request.ID == 0)
        {
            Proizvodjac = new Proizvodjac();
            _applicationDbContext.Add(Proizvodjac);
        }
        else
        {
            Proizvodjac = _applicationDbContext.Proizvodjac.FirstOrDefault(p =>
                p.ID == request.ID
            );
        }

        Proizvodjac.Naziv = request.Naziv;
        await _applicationDbContext.SaveChangesAsync();
        return Proizvodjac.ID;
    }
}