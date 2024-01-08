namespace itservicecenter.Entities.Endpoints.GradEndpoints.GetAll
{
    public record GradGetAllResponse (List <GradGetAllResponseGrad> Gradovi);
    public record GradGetAllResponseGrad (int ID , string Naziv);
}
