using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace itservicecenter.Entities.Models
{
    [Table("KorsnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Passweord { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsServiser { get; set; }
        public bool IsProdavac { get; set; }
        public bool Is2FActive { get; set; }
        public bool JelObrisan { get; set; }
        public string? SlikaKorisnikaMala { get; set; }
        public string? SlikaKorisnikaVelika { get; set; }
    }
}
