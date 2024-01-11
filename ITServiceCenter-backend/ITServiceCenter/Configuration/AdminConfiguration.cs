using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
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
                }

            );

        }
    }
}
