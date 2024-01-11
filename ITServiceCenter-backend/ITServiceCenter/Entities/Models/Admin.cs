using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    [Table("Admin")]
    public class Admin : KorisnickiNalog
    {
        [Key]
        // public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
