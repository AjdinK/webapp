using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ServisniNalogConfiguration : IEntityTypeConfiguration<ServisniNalog>
    {
        public void Configure(EntityTypeBuilder<ServisniNalog> builder)
        {
            builder.HasData(
                new ServisniNalog
                {
                    ID= 1,
                    SifraNaloga = "sifraservisa1",
                    DatumZaprimanja = DateTime.Now,
                    DatumPredaje = DateTime.Now.AddDays(2),
                    Napomena = "Ocistiti prednju kameru",
                    Problem = "Zamjena LCDa"
                },
                 new ServisniNalog
                 {
                     ID = 2,
                     SifraNaloga = "sifraservisa2",
                     DatumZaprimanja = DateTime.Now,
                     DatumPredaje = DateTime.Now.AddDays(2),
                     Napomena = "",
                     Problem = "zakljucan google acc"
                 },
                   new ServisniNalog
                   {
                       ID = 3,
                       SifraNaloga = "sifraservisa3",
                       DatumZaprimanja = DateTime.Now,
                       DatumPredaje = DateTime.Now.AddDays(2),
                       Napomena = "bitini podatci",
                       Problem = "Spor"
                   },
                     new ServisniNalog
                     {
                         ID = 4,
                         SifraNaloga = "sifraservisa4",
                         DatumZaprimanja = DateTime.Now,
                         DatumPredaje = DateTime.Now.AddDays(2),
                         Napomena = "",
                         Problem = "Nema slike"
                     },
                       new ServisniNalog
                       {
                           ID = 5,
                           SifraNaloga = "sifraservisa5",
                           DatumZaprimanja = DateTime.Now,
                           DatumPredaje = DateTime.Now.AddDays(2),
                           Napomena = "",
                           Problem = "Ne radi brzo punjenje!"
                       }
                );
        }
    }
}
