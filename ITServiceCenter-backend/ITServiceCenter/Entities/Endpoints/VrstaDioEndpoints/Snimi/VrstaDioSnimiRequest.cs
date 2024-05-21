using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Snimi
{
    public class VrstaDioSnimiRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
    }
}