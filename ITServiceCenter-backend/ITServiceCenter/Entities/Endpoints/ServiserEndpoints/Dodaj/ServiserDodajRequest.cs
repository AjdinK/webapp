using System.ComponentModel.DataAnnotations;
using itservicecenter.Helper;

namespace itservicecenter.Entities.Endpoints.ServiserEndpoints.Dodaj;

public class ServiserDodajRequest
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

    public bool IsServiser { get; set; }
    public int GradID { get; set; }
    public int SpolID { get; set; }

    [Required(ErrorMessage = "Obavezno polje")]
    [ValidatorLozinka]
    public string Lozinka { get; set; }

    public string? SlikaKorisnikaBase64 { get; set; }
}