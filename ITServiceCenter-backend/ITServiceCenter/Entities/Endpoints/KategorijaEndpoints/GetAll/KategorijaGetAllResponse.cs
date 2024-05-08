namespace itservicecenter.Entities.Endpoints.KategorijaEndpoints.GetAll
{
    public class KategorijaGetAllResponse
    {
        public List<KategorijaGetAllResponseKategorija> Kategorije { get; set; }
    }

    public class KategorijaGetAllResponseKategorija
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
