namespace itservicecenter.Entities.Models
{
    public class KorisnickiNalog
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string passweord { get; set; }
        public bool isAdmin { get; set; }
        public bool isServiser { get; set; }
        public bool isProdavac { get; set; }

    }
}
