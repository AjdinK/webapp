using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class Prodavac_Uredjaj
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Prodavac))]
        public int ProdavacID { get; set; }
        public Prodavac Prodavac { get; set; }

        [ForeignKey(nameof(Uredjaj))]
        public int UredjajID { get; set; }
        public Uredjaj Uredjaj { get; set; }

        [ForeignKey(nameof(ServisniNalog))]
        public int ServisniNalogID { get; set; }
        public ServisniNalog ServisniNalog { get; set; }

        [ForeignKey(nameof(Racun))]
        public int RacunID { get; set; }
        public Racun Racun { get; set; }
    }
}
