namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.GetAll
{
    public class ServiserGetAllResponse {
        public List <ServiserGetAllResponseServiser> ListaServiser { get; set; }
    }

    public class ServiserGetAllResponseServiser
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }
        public bool IsServiser { get; set; }
    }
}
