using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class GradConfiguration : IEntityTypeConfiguration<Grad>
    {
        public void Configure(EntityTypeBuilder<Grad> builder)
        {
            builder.HasData(
                new Grad
                {
                    ID = 1,
                    Naziv = "Zenica",
                },
                new Grad
                {
                    ID = 2,
                    Naziv = "Bihać",
                },
                new Grad
                {
                    ID = 3,
                    Naziv = "Bijeljina",
                },
                new Grad
                {
                    ID = 4,
                    Naziv = "Mostar",
                },
                new Grad
                {
                    ID = 5,
                    Naziv = "Cazin",
                },
                new Grad
                {
                    ID = 6,
                    Naziv = "Čapljina",
                },
                new Grad
                {
                    ID = 7,
                    Naziv = "Drventa",
                },
                new Grad
                {
                    ID = 8,
                    Naziv = "Doboj",
                },
                new Grad
                {
                    ID = 9,
                    Naziv = "Goražde",
                },
                new Grad
                {
                    ID = 10,
                    Naziv = "Gračanica",
                },
                new Grad
                {
                    ID = 11,
                    Naziv = "Gradačac",
                },
                new Grad
                {
                    ID = 12,
                    Naziv = "Gradiška",
                },
                new Grad
                {
                    ID = 13,
                    Naziv = "Konjic",
                },
                new Grad
                {
                    ID = 14,
                    Naziv = "Laktaši",
                },
                new Grad
                {
                    ID = 15,
                    Naziv = "Livno",
                },
                new Grad
                {
                    ID = 16,
                    Naziv = "Lukavac",
                },
                new Grad
                {
                    ID = 17,
                    Naziv = "Ljubuški",
                },
                new Grad
                {
                    ID = 18,
                    Naziv = "Bosanska Krupa",
                },
                new Grad
                {
                    ID = 19,
                    Naziv = "Orašje",
                },
                new Grad
                {
                    ID = 20,
                    Naziv = "Prijedor",
                },
                new Grad
                {
                    ID = 21,
                    Naziv = "Prnjavor",
                },
                new Grad
                {
                    ID = 22,
                    Naziv = "Sarajevo",
                },
                new Grad
                {
                    ID = 23,
                    Naziv = "Srebrenik",
                },
                new Grad
                {
                    ID = 24,
                    Naziv = "Stolac",
                },
                new Grad
                {
                    ID = 25,
                    Naziv = "Široki Brijeg",
                },
                new Grad
                {
                    ID = 26,
                    Naziv = "Travnik",
                },
                new Grad
                {
                    ID = 27,
                    Naziv = "Tuzla",
                },
                new Grad
                {
                    ID = 28,
                    Naziv = "Visoko",
                },
                new Grad
                {
                    ID = 29,
                    Naziv = "Zavidovići",
                },
                new Grad
                {
                    ID = 30,
                    Naziv = "Banja Luka",
                },
                new Grad
                {
                    ID = 31,
                    Naziv = "Zvornik",
                },
                new Grad
                {
                    ID = 32,
                    Naziv = "Živinice",
                },
                new Grad
                {
                    ID = 33,
                    Naziv = "Donji Vakuf",
                },
                new Grad
                {
                    ID = 34,
                    Naziv = "Zavidovići",
                });
        }
    }
}
