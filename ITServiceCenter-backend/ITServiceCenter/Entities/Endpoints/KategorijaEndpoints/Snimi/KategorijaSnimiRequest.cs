using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.Snimi
{
    public class KategorijaSnimiRequest
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
    }
}