using itservicecenter.Data;
using itservicecenter.Entities.Endpoints.VrstaDioEndpoints.GetAll;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.GetAll
{
    public class ProizvodjacGetAllEndpoint : MyBaseEndpoint <NoRequest , ProizvodjacGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProizvodjacGetAllEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Proizvodjac/GetAll")]
        public override async Task<ProizvodjacGetAllResponse> Obradi ([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Proizvodjac
                .OrderBy(v => v.ID)
                .Select(v => new ProizvodjacGetAllResponseProizvodjac
                {
                    ID = v.ID,
                    Naziv = v.Naziv,
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return new ProizvodjacGetAllResponse
            {
                ListaProizvodjaca = data
            };
        }
    }
}
