using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.Snimi
{
    public class ProizvodjacSnimiEndpoint : MyBaseEndpoint<ProizvodjacSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodjacSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Proizvodjac/Snimi")]
        public override async Task<int> Obradi(
            [FromBody] ProizvodjacSnimiRequest request,
            CancellationToken cancellationToken
        )
        {
            Models.Proizvodjac? Proizvodjac;
            if (request.ID == 0)
            {
                Proizvodjac = new Models.Proizvodjac();
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
}
