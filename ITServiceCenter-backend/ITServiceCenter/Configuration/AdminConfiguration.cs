using FIT_Api_Examples.Helper;
using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration <Admin>
    {
        public void Configure(EntityTypeBuilder <Admin> builder)
        {
            builder.HasData(
                new Admin
                {
                    ID = 1,
                    Ime = "Ajdin",
                    Prezime = "Kuduzović",
                    Username = "ajdin",
                    Passweord ="ajdin",
                    IsAdmin = true,
                    IsProdavac = false,
                    IsServiser = false,
                    GradID = 22,
                    SpolID = 1,
                    Email = "test@test.com",
                    JelObrisan = false,
                },
                  new Admin
                {
                    ID = 6,
                    Ime = "test",
                    Prezime = "test",
                    Username = "test",
                    Passweord ="test",
                    IsAdmin = true,
                    IsProdavac = true,
                    IsServiser = true,
                    GradID = 1,
                    SpolID = 1,
                    Email = "test@test.com",
                    JelObrisan = false,
                  }
            );
        }
    }
}
