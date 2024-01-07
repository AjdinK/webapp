using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Ocjena
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public int UnesenaOcjena { get; set; }
        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public int PredmetID { get; set; }
        [ForeignKey(nameof(PredmetID))]
        public Predmet Predmet { get; set; }
    }
}
