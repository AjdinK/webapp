using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ProdavacConfiguration : IEntityTypeConfiguration<Prodavac>
    {
        public void Configure(EntityTypeBuilder<Prodavac> builder)
        {
            var salt = PasswordGenerator.GenerateSalt();
            var hash = PasswordGenerator.GenerateHash(salt, "alina");

            builder.HasData(
                new Prodavac
                {
                    ID = 4,
                    Ime = "Alina",
                    Prezime = "Burić",
                    GradID = 4,
                    SpolID = 2,
                    Username = "alina",
                    IsProdavac = true,
                    Email = "alina@alina.com",
                    JelObrisan = false,
                    LozinkaSalt = salt,
                    LozinkaHash = hash
                }
            );

            salt = PasswordGenerator.GenerateSalt();
            hash = PasswordGenerator.GenerateHash(salt, "vedad");

            builder.HasData(
                new Prodavac
                {
                    ID = 5,
                    Ime = "Vedad",
                    Prezime = "Keskin",
                    GradID = 4,
                    SpolID = 1,
                    Username = "vedad",
                    IsProdavac = true,
                    Email = "vedad@vedad.com",
                    JelObrisan = false,
                    LozinkaSalt = salt,
                    LozinkaHash = hash
                }
            );
        }
    }
}