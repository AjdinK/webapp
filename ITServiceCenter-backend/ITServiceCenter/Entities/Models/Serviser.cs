using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    public class Serviser
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Pezime { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }

        [ForeignKey(nameof(Spol))]
        public int SpolID { get; set; }
        public Spol Spol { get; set; }
    }
}
