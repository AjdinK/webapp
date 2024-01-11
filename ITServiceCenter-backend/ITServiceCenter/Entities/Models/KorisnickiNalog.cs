using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    [Table("KorsnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Passweord { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsServiser { get; set; }
        public bool IsProdavac { get; set; }
        public bool is2FActive { get; set; }
    }
}
