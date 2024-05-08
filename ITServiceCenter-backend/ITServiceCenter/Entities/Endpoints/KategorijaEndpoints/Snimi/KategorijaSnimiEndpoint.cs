using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.Snimi
{
    public class KategorijaSnimiEndpoint : MyBaseEndpoint<KategorijaSnimiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategorijaSnimiEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpPost("Kategorija/Snimi")]
        public override async Task<int> Obradi(
            [FromBody] KategorijaSnimiRequest request,
            CancellationToken cancellationToken
        )
        {
            Models.Kategorija? Kategorija;
            if (request.ID == 0)
            {
                Kategorija = new Models.Kategorija();
                _applicationDbContext.Add(Kategorija);
            }
            else
            {
                Kategorija = _applicationDbContext.Kategorija.FirstOrDefault(k =>
                    k.ID == request.ID
                );
            }

            Kategorija.Naziv = request.Naziv;
            await _applicationDbContext.SaveChangesAsync();
            return Kategorija.ID;
        }
    }
}
