using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class Serviser_Kategorija
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Serviser))]
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }

        [ForeignKey(nameof(Kategorija))]
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
