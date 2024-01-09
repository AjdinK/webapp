using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace itservicecenter.Entities.Models
{
    public class AutenfitikacijaToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }
        [ForeignKey(nameof(korisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string? IpAdresa { get; set; }
        [JsonIgnore]

        public string? TwoFKey { get; set; }
        public bool IsOtkljucano { get; set; }

    }
}
