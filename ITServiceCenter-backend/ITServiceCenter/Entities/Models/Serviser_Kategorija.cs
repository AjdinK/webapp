namespace itservicecenter.Entities.Models
{
    public class Serviser_Kategorija
    {
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }
        public int KategorijaID { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
