using itservicecenter.Entities.Models;

namespace itservicecenter.Entities.Endpoints.AdminEndpoints.GetById
{
    public class AdminGetByIdResponse
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsServiser { get; set; }
        public bool IsProdavac { get; set; }
        public int GradId { get; set; }
        public int SpolId { get; set; }

    }
}

                 