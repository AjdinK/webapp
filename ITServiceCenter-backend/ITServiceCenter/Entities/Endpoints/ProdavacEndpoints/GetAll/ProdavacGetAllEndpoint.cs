using FIT_Api_Examples.Helper;
using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.GetByID
{
    public class ProdavacGetAllEndpoint
        : MyBaseEndpoint<ProdavacGetAllRequest, ProdavacGetAllResponse>
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ProdavacGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Prodavac/GetAll")]
        public override async Task<ProdavacGetAllResponse> Obradi(
            [FromQuery] ProdavacGetAllRequest request,
            CancellationToken cancellationToken
        )
        {
            var data = _ApplicationDbContext
                .Prodavac.OrderBy(p => p.ID)
                .Where(p => !p.JelObrisan)
                .Select(p => new ProdavacGetAllResponseProdavac
                {
                    ID = p.ID,
                    Ime = p.Ime,
                    Prezime = p.Prezime,
                    Username = p.Username,
                    IsProdavac = p.IsProdavac,
                    GradID = p.GradID,
                    SpolID = p.SpolID,
                    Email = p.Email,
                    SlikaKorisnikaBase64 = p.SlikaKorisnikaVelika,
                });
            var pagedProdavac = PagedList<ProdavacGetAllResponseProdavac>.Create(
                data,
                request.PageNumber,
                request.PageSize
            );

            return new ProdavacGetAllResponse
            {
                ListaProdavac = pagedProdavac.DataItems,
                CurrentPage = pagedProdavac.CurrentPage,
                TotalPages = pagedProdavac.TotalPages,
                PageSize = pagedProdavac.PageSize,
                TotalCount = pagedProdavac.TotalCount,
                HasPrevios = pagedProdavac.HasPrevios,
                HasNext = pagedProdavac.HasNext,
            };
        }
    }
}
