using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Helper.AutentifikacijaAutorizacija
{
    [ApiController]
    //[Route("[controller] / [action]")]
    public abstract class MyBaseEndpint<TRequest, TResponse>:ControllerBase 
    {
        public abstract Task<TResponse> Handle(TRequest request);
    }
}
