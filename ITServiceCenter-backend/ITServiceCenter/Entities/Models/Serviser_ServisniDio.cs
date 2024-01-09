namespace itservicecenter.Entities.Models
{
    public class Serviser_ServisniDio
    {
        public int ServiserID { get; set; }
        public Serviser Serviser { get; set; }
        public int ServisniDioID { get; set; }
        public ServisniDio ServisniDio { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }

    }
}
