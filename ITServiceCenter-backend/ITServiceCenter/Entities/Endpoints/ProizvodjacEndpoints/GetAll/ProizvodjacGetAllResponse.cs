using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.GetAll
{
    public class ProizvodjacGetAllResponse
    {
        public List<ProizvodjacGetAllResponseProizvodjac> ListaProizvodjaca { get; set; }
    }

    public class ProizvodjacGetAllResponseProizvodjac
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Naziv { get; set; }
    }
}