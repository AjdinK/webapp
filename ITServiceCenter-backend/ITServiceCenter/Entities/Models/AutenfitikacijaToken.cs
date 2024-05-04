using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace itservicecenter.Entities.Models
{
    public class AutenfitikacijaToken
    {
        [Key]
        public int ID { get; set; }
        public string Vrijednost { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        public bool IsOtkljucano { get; set; }

        [JsonIgnore]
        public string? TwoFKey { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }

    }
}
