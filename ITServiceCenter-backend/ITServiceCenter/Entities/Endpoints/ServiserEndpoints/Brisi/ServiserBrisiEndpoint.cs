using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.Brisi
{
    public class ServiserBrisiEndpoint : MyBaseEndpoint<ServiserBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ServiserBrisiEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpDelete ("Serviser/Brisi")]
        public override async Task <int> Obradi ([FromQuery] ServiserBrisiRequest request, CancellationToken cancellationToken)
        {
            var Serviser = _applicationDbContext.Serviser.FirstOrDefault ( s => s.ID == request.ID);

            if (Serviser != null) {
                Serviser.JelObrisan = true;
                await _applicationDbContext.SaveChangesAsync(cancellationToken : cancellationToken);
                return request.ID;
            }
            else {
                throw new Exception ("Pogresen ID");
            }
        }
    }
}