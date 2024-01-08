namespace itservicecenter.Entities.Endpoints.GradEndpoints.Pretrega
{
    public class GradPretregaResponse
    {
        public List<GradPretregaResponseGrad> Gradovi { get; set; }
    }
    public class GradPretregaResponseGrad
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
