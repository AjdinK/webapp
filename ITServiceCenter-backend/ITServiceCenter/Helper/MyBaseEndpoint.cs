using Microsoft.AspNetCore.Mvc;

namespace itservicecenter.Helper
{
    public abstract class MyBaseEndpoint <TRequest,TResponse> : ControllerBase
    {
        public abstract Task <TResponse> Obradi (TRequest request, CancellationToken cancellationToken);
    }
}
