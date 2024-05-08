namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetAll
{
    public class GradGetAllResponse
    {
        public List<GradGetAllResponseGrad> Gradovi { get; set; }
    }

    public class GradGetAllResponseGrad
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
