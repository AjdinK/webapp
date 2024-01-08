using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class Uredjaj
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
