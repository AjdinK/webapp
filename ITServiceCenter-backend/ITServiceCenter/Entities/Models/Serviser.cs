using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class Serviser
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Pezime { get; set; }
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public int SpolID { get; set; }
        public Spol Spol { get; set; }
    }
}
