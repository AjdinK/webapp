namespace itservicecenter.Entities.Models
{
    public class Prodavac_Uredjaj
    {
        public int ProdavacID { get; set; }
        public Prodavac Prodavac { get; set; }
        public int UredjajID { get; set; }
        public Uredjaj Uredjaj { get; set; }
        public int ServisniNalogID { get; set; }
        public ServisniNalog ServisniNalog { get; set; }
        public int RacunID { get; set; }
        public Racun Racun { get; set; }
    }
}
