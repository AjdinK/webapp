using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.GetAll
{
    public class ServiserGetAllEndpoint
        : MyBaseEndpoint<ServiserGetAllRequset, ServiserGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ServiserGetAllEndpoint(ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet("Serviser/GetAll")]
        [AllowAnonymous]
        public override async Task<ServiserGetAllResponse> Obradi(
            [FromQuery] ServiserGetAllRequset request,
            CancellationToken cancellationToken
        )
        {
            var data = _applicationDbContext
                .Serviser.OrderBy(s => s.ID)
                .Where(s => !s.JelObrisan)
                .Select(s => new ServiserGetAllResponseServiser
                {
                    ID = s.ID,
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Username = s.Username,
                    Email = s.Email,
                    GradID = s.GradID,
                    SpolID = s.SpolID,
                    IsServiser = s.IsServiser,
                    SlikaKorisnikaBase64 = s.SlikaKorisnikaVelika
                });

            var pagedList = PagedList<ServiserGetAllResponseServiser>.Create(
                data,
                request.PageNumber,
                request.PageSize
            );

            return new ServiserGetAllResponse
            {
                ListaServiser = pagedList.DataItems,
                CurrentPage = pagedList.CurrentPage,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                HasNext = pagedList.HasNext,
                HasPrevios = pagedList.HasPrevios
            };
        }
    }
}
