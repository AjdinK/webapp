namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.GetByID
{
    public class ProdavacGetByIDResponse
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public bool IsProdavac { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }
        public string Email { get ; set;}
        public string? SlikaKorisnikaNovaString { get; set; }

    }
}