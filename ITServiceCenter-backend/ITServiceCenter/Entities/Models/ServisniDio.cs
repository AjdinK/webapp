using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class ServisniDio
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        [ForeignKey(nameof(Proizvodjac))]
        public int ProizvodjacID { get; set; }
        public Proizvodjac Proizvodjac { get; set; }

        [ForeignKey(nameof(VrstaDio))]
        public int VrstaDioID { get; set; }
        public VrstaDio VrstaDio { get; set; }
    }
}
