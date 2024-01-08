namespace itservicecenter.Entities.Models
{
    public class Serviser_Uredjaj
    {
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }
        public int UredjajID { get; set; }
        public Uredjaj Uredjaj { get; set; }
        public string Status { get; set; }
        public bool Popravljeno { get; set; }
    }
}
