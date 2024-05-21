using System.ComponentModel.DataAnnotations;
using itservicecenter.Helper;

namespace itservicecenter.Entities.Endpoints.AuthEndpoints
{
    public class AuthLoginRequest
    {
        // public string Email { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [ValidatorLozinka]
        public string Lozinka { get; set; }
    }
}