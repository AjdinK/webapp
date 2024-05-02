using FIT_Api_Examples.Helper;

namespace ITServiceCenter.Entities.Endpoints.ProdavacEndpoints.GetByID
{
    public class ProdavacGetAllResponse
    {
        public List <ProdavacGetAllResponseProdavac> ListaProdavac { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevios { get; set; }
        public bool HasNext { get; set; }
    }

    public class ProdavacGetAllResponseProdavac {
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