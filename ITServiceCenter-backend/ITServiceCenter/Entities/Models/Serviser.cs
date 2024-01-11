﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace itservicecenter.Entities.Models
{
    [Table("Serviser")]
    public class Serviser : KorisnickiNalog
    {
        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }

        [ForeignKey(nameof(Spol))]
        public int SpolID { get; set; }
        public Spol Spol { get; set; }
    }
}
