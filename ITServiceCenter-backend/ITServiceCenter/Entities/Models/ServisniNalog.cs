using System.ComponentModel.DataAnnotations;

namespace itservicecenter.Entities.Models
{
    public class ServisniNalog
    {
        [Key]
        public int ID { get; set; }
        public string SifraNaloga { get; set; }
        public DateTime DatumZaprimanja { get; set; }
        public DateTime DatumPredaje { get; set; }
        public string Napomena { get; set; }
        public string Problem { get; set; }
    }
}
