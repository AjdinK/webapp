using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class RacunConfiguration : IEntityTypeConfiguration<Racun>
    {
        public void Configure(EntityTypeBuilder<Racun> builder)
        {
            builder.HasData(
                new Racun
                {
                    ID = 1,
                    SifraRacuna = "sifraracuna1",
                    DatumPreuzimanja = DateTime.Now,
                    CijenaServisa = 210,
                    Garancija = "30 Dana",
                    Napomena = ""
                });
        }
    }
}
