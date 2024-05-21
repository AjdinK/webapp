using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.Snimi
{
    public class ProizvodjacSnimiRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
    }
}