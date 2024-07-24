using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints;

public class AuthLogoutRequest
{
    [Required(ErrorMessage = "Obavezno polje")]
    public string Token { get; set; }
}