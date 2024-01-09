namespace itservicecenter.Entities.Endpoints.FAQEndpoints.GetAll
{
    public record FAQGetAllResponse (List<FAQGetAllResponseFAQ> FAQLista);
    public record FAQGetAllResponseFAQ (int ID , string Pitanje , string Odgovor);

}
