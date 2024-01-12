namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.GetAll
{
    public class VrstaDioGetAllResponse
    {
        public List<VrstaDioGetAllResponseVrstaDio> ListaVrstaDio { get; set; } 
    }
    public class VrstaDioGetAllResponseVrstaDio { 
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
