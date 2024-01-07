namespace FIT_Api_Example.Endpoints.Ispit.Dodaj
{
    public class PrijavaIspitaDodajRequest
    {
        public int IspitId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public int PredmetID { get; set; }
        public string PuniNaziv { get; set; }
        public string Sifra { get; set; }
        public int Bodovi { get; set; }
        public string Komentar { get; set; }

        public string Opis => PuniNaziv + ": " + Sifra;
    }
}
