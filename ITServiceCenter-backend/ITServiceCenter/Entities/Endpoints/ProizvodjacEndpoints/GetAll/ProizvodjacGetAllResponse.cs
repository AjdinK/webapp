namespace itservicecenter.Entities.Endpoints.ProizvodjacEndpoints.GetAll
{
    public class ProizvodjacGetAllResponse
    {
        public List<ProizvodjacGetAllResponseProizvodjac> ListaProizvodjaca { get; set; }
    }
    public class ProizvodjacGetAllResponseProizvodjac {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
