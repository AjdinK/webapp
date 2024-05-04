using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace itservicecenter.Entities.Models
{
    public class FAQ
    {
        [Key]
        public int ID { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
    }
}
