using itservicecenter.Entities.Models;
using itservicecenter.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            var salt = PasswordGenerator.GenerateSalt();
            var hash = PasswordGenerator.GenerateHash(salt, "ajdin");

            builder.HasData(
                new Admin
                {
                    ID = 1,
                    Ime = "Ajdin",
                    Prezime = "Kuduzović",
                    Username = "ajdin",
                    IsAdmin = true,
                    IsProdavac = false,
                    IsServiser = false,
                    GradID = 22,
                    SpolID = 1,
                    Email = "ajdin@ajdin.com",
                    JelObrisan = false,
                    LozinkaSalt = salt,
                    LozinkaHash = hash
                }
            );
        }
    }
}