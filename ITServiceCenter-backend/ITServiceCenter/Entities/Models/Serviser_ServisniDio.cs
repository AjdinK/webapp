using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class Serviser_ServisniDio
    {
        [Key]
        public int ServiserServisniDioID { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey(nameof(Serviser))]
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }

        [ForeignKey(nameof(ServisniDio))]
        public int ServisniDioID { get; set; }
        public ServisniDio ServisniDio { get; set; }

    }
}
