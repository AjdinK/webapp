using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ServiserConfiguration : IEntityTypeConfiguration<Serviser>
    {
        public void Configure(EntityTypeBuilder<Serviser> builder)
        {
            var salt = PasswordGenerator.GenerateSalt();
            var hash = PasswordGenerator.GenerateHash(salt, "jasir");

            builder.HasData(
                new Serviser
                {
                    ID = 2,
                    Ime = "Jasir",
                    Prezime = "Burić",
                    GradID = 1,
                    SpolID = 1,
                    IsServiser = true,
                    Username = "jasir",
                    Email = "test@test.com",
                    JelObrisan = false,
                    LozinkaSalt = salt,
                    LozinkaHash = hash
                }
            );

            salt = PasswordGenerator.GenerateSalt();
            hash = PasswordGenerator.GenerateHash(salt, "jasir");

            builder.HasData(
                new Serviser
                {
                    ID = 3,
                    Ime = "Adis",
                    Prezime = "Mešić",
                    GradID = 1,
                    SpolID = 1,
                    IsServiser = true,
                    Username = "adis",
                    Email = "test@test.com",
                    JelObrisan = false,
                    LozinkaSalt = salt,
                    LozinkaHash = hash
                }
            );
        }
    }
}