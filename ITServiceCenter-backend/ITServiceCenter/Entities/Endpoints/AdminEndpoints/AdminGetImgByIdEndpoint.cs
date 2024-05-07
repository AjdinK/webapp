using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints
{
    public class AdminGetImgByIdEndpoint : MyBaseEndpoint<int,byte[]>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public AdminGetImgByIdEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Admin/GetImgById")]
        public override async Task<byte[]> Obradi([FromQuery] int request, CancellationToken cancellationToken)
        {
            var admin = await _ApplicationDbContext.Admin.FirstOrDefaultAsync(admin => admin.ID == request);
            if (admin == null)
                throw new Exception("User ID Not Found");

            return admin.SlikaKorisnikaTrenutnoBajt;
        }
    }
}