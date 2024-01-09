using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class Serviser_Uredjaj
    {
        [Key]
        public int ID { get; set; }
        public string Status { get; set; }
        public bool Popravljeno { get; set; }

        [ForeignKey(nameof(Serviser))]
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }

        [ForeignKey(nameof(Uredjaj))]
        public int UredjajID { get; set; }
        public Uredjaj Uredjaj { get; set; }

    }
}
