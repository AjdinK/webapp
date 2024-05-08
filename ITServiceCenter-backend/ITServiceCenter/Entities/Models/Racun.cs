using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class Racun
    {
        [Key]
        public int ID { get; set; }
        public string SifraRacuna { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public string Napomena { get; set; }
        public float CijenaServisa { get; set; }
        public string Garancija { get; set; }
    }
}
