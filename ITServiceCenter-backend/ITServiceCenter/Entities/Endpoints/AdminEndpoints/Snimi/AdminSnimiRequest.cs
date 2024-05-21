using System.ComponentModel.DataAnnotations;
using itservicecenter.Helper;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints.Snimi
{
    public class AdminSnimiRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [EmailAddress(ErrorMessage = "Unesite validan email")]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsServiser { get; set; }
        public bool IsProdavac { get; set; }
        public int GradId { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [ValidatorLozinka]
        public string Lozinka { get; set; }

        public string? SlikaKorisnikaBase64 { get; set; }
    }
}