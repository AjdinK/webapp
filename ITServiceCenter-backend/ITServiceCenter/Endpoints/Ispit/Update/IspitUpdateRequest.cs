namespace FIT_Api_Example.Endpoints.Ispit.Update
{
    public class IspitUpdateRequest
    {
        public int IspitID { get; set; }
        public DateTime Datum { get; set; }
        public string Komentar { get; set; }
    }
}
