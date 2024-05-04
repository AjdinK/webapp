using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.Brisi
{
    public class KategorijaBrisiEndpoint : MyBaseEndpoint <KategorijaBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public KategorijaBrisiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete("Kategorija/brisi")]
        public override async Task <int> Obradi ([FromQuery] KategorijaBrisiRequest request, CancellationToken cancellationToken)
        {
            var data = _applicationDbContext.Kategorija.FirstOrDefault(k => k.ID == request.ID);
            if (data != null)
            {
                _applicationDbContext.Kategorija.Remove(data);
                await _applicationDbContext.SaveChangesAsync();
                return (request.ID);
            }
            else {
                throw new Exception("Error -> Pogresen ID");
            }
        }
    }
}
