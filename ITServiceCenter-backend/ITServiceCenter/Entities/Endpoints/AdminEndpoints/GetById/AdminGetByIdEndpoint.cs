using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints.GetById
{
    public class AdminGetByIdEndpoint : MyBaseEndpoint<AdminGetByIdRequest, AdminGetByIdResponse>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public AdminGetByIdEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Admin/GetById")]
        [Authorize(Roles = "Admin")]
        public override async Task<AdminGetByIdResponse> Obradi(
            [FromQuery] AdminGetByIdRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = await _ApplicationDbContext
                .Admin.OrderBy(a => a.ID)
                .Select(a => new AdminGetByIdResponse
                {
                    Id = a.ID,
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    Email = a.Email,
                    SpolId = a.SpolID,
                    GradId = a.GradID,
                    IsAdmin = a.IsAdmin,
                    IsServiser = a.IsServiser,
                    IsProdavac = a.IsProdavac,
                    Username = a.Username,
                    SlikaKorisnikaBase64 = a.SlikaKorisnikaVelika
                })
                .SingleAsync(a => a.Id == request.Id, cancellationToken);

            return data;
        }
    }
}