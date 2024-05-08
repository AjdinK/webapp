using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.AdminEndpoints.GetAll
{
    public class AdminGetAllEndpoint : MyBaseEndpoint<NoRequest, AdminGetAllResponse>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public AdminGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Admin/GetAll")]
        public override async Task<AdminGetAllResponse> Obradi(
            [FromQuery] NoRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = await _ApplicationDbContext
                .Admin.OrderBy(a => a.ID)
                .Select(a => new AdminGetAllResponseAdmin
                {
                    ID = a.ID,
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    Username = a.Username,
                    IsAdmin = a.IsAdmin,
                    IsProdavac = a.IsProdavac,
                    IsServiser = a.IsServiser,
                    GradID = a.GradID,
                    SpolID = a.SpolID,
                    Email = a.Email,
                    SlikaKorisnikaBase64 = a.SlikaKorisnikaVelika,
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return new AdminGetAllResponse { ListaAdmin = data };
        }
    }
}
