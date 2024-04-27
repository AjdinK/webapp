using FIT_Api_Examples.Helper;
using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ServiserConfiguration : IEntityTypeConfiguration<Serviser>
    {
        public void Configure (EntityTypeBuilder<Serviser> builder)
        {
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
                    Passweord = "jasir",
                    Email = "test@test.com",
                    JelObrisan = false,
                    SlikaKorisnikaTrenutnoBajt = Fajlovi.Ucitaj("wwwroot/profile_images/empty.png"),
                },
                new Serviser
                {
                    ID = 3,
                    Ime = "Adis",
                    Prezime = "Mešić",
                    GradID = 1,
                    SpolID = 1,
                    IsServiser = true,
                    Username = "adis",
                    Passweord = "adis",
                    Email = "test@test.com",
                    JelObrisan = false,
                    SlikaKorisnikaTrenutnoBajt = Fajlovi.Ucitaj("wwwroot/profile_images/empty.png"),
                }
                );
        }
    }
}
