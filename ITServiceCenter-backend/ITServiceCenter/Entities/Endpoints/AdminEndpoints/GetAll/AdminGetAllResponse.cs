namespace ITServiceCenter.Entities.Endpoints.AdminEndpoints.GetAll
{
    public class AdminGetAllResponse
    {
        public List <AdminGetAllResponseAdmin> ListaAdmin {get;set;}
    }

    public class AdminGetAllResponseAdmin {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsProdavac { get; set; }
        public bool IsServiser { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }
        public string? SlikaKorisnikaNovaString { get; set; }

    }
}