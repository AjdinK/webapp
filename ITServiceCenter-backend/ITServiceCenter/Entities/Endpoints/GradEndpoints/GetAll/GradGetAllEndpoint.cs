﻿using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetAll
{
    [Route("Grad")]
    public class GradGetAllEndpoint : MyBaseEndpoint<NoRequest, GradGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GradGetAllEndpoint (ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }

        [HttpGet ("GetAll")]
        public override async Task <GradGetAllResponse> Obradi ([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var data = await _applicationDbContext.Grad
                .OrderBy(g => g.ID)
                .Select(g => new GradGetAllResponseGrad (g.ID , g.Naziv))
                .ToListAsync(cancellationToken: cancellationToken);

            return new GradGetAllResponse(data);
        }
    }
}
