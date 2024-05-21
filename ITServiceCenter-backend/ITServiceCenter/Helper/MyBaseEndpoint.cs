using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Helper
{
    [ApiController]
    [Authorize]
    public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
    {
        public abstract Task<TResponse> Obradi(
            TRequest request,
            CancellationToken cancellationToken
        );
    }
}