using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
