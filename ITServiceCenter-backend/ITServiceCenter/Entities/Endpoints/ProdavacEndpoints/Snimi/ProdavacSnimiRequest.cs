using System.ComponentModel.DataAnnotations;
using itservicecenter.Helper;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.Snimi
{
    public class ProdavacSnimiRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [EmailAddress(ErrorMessage = "Unesite validan email")]
        public string Email { get; set; }

        public bool IsProdavac { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [ValidatorLozinka]
        public string Lozinka { get; set; }

        public string? SlikaKorisnikaBase64 { get; set; }
    }
}