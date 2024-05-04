using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.Snimi
{
    public class ProdavacSnimiRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsProdavac { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }
        public string? SlikaKorisnikaNovaString { get; set; }

    }
}