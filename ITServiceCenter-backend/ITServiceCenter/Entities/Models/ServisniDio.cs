using System.ComponentModel.DataAnnotations;
namespace itservicecenter.Entities.Models
{
    public class ServisniDio
    {
        [Key]
        public int ID { get; set; }
        public int ProizvodjacID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public int VrstaDioID { get; set; }
        public VrstaDio VrstaDio { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
    }
}

