namespace itservicecenter.Entities.Endpoints.VrstaDioEndpoints.Pretrega
{
    public class VrstaDioPretregaResponse
    {
        public List<VrstaDioPretregaResponseVrstaDio> ListaVrstaDio { get; set; }
    }

    public class VrstaDioPretregaResponseVrstaDio
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}