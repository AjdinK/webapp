namespace FIT_Api_Example.Endpoints.Ispit.Pretraga
{
    public class IspitPretragaResponse
    {
        public List<IspitPretragaResponseIspiti> IspitPretragaRespons { get; set; }
    }

    public class IspitPretragaResponseIspiti
    {
        public int IspitId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public int PredmetID { get; set; }
        public string PuniNaziv { get; set; }
        public string Sifra { get; set; }
        public int Bodovi { get; set; }

        public string Opis => PuniNaziv + ": " + Sifra;
    }
}
