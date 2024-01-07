using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Example.Modul0_Autentifikacija.Models;

namespace FIT_Api_Example.Data.Models
{
    [Table("Nastavnik")]
    public class Nastavnik : KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
