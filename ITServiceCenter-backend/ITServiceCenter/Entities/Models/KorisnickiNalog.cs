using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Passweord { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsServiser { get; set; }
        public bool IsProdavac { get; set; }

    }
}
