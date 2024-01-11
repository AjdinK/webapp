namespace itservicecenter.Entities.Endpoints.FAQEndpoints.GetAll
{
    public class FAQGetAllResponse {
        public List<FAQGetAllResponseFAQ> FAQLista { get; set; }
    }

    public class FAQGetAllResponseFAQ {
        public int ID { get; set; }
        public string Pitanje { get; set; }
        public string Odgovor { get; set; }
    }
}
