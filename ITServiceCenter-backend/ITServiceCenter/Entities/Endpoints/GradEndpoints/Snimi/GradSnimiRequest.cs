using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.GradEndpoints.Dodaj
{
    public class GradSnimiRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
    }
}