﻿using itservicecenter.Data;
using itservicecenter.Helper;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.Brisi
{
    public class ProizvodjacBrisiEndpoint : MyBaseEndpoint<ProizvodjacBrisiRequest, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProizvodjacBrisiEndpoint ( ApplicationDbContext ApplicationDbContext)
        {
            _applicationDbContext = ApplicationDbContext;
        }
        [HttpDelete ("Proizvodjac/Brisi")]
        public override async Task <int> Obradi([FromQuery] ProizvodjacBrisiRequest request, CancellationToken cancellationToken)
        {
            var data = _applicationDbContext.Proizvodjac.FirstOrDefault(p => p.ID == request.ID);
            if (data != null)
            {
                _applicationDbContext.Remove(data);
                await _applicationDbContext.SaveChangesAsync(cancellationToken: cancellationToken);
                return request.ID;
            }
            else {
                throw new Exception("Pogresen ID");
            }
        }
    }
}
