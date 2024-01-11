using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ProdavacConfiguration : IEntityTypeConfiguration<Prodavac>
    {
        public void Configure(EntityTypeBuilder<Prodavac> builder)
        {
            builder.HasData(
                new Prodavac
                {
                    ID = 4,
                    Ime = "Alina",
                    Prezime = "Burić",
                    GradID = 4,
                    SpolID = 2,
                    Username = "alina",
                    Passweord = "alina",
                    IsProdavac = true,
                },
                new Prodavac
                {
                    ID = 5,
                    Ime = "Vedad",
                    Prezime = "Keskin",
                    GradID = 4,
                    SpolID = 1,
                    Username = "vedad",
                    Passweord = "vedad",
                    IsProdavac = true,
                }

                );
        }
    }
}
