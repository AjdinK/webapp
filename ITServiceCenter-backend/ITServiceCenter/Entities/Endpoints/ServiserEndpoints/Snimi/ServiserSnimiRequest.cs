namespace ITServiceCenter.Entities.Endpoints.ServiserEndpoints.Snimi
{
    public class ServiserSnimiRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IsServiser { get; set; }
        public int GradID { get; set; }
        public int SpolID { get; set; }
        public string? SlikaKorisnikaBase64 { get; set; }
    }
}
