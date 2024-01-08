namespace itservicecenter.Entities.Models
{
    public class Prodavac
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public int SpolID { get; set; }
        public Spol Spol { get; set; }
    }
}
