using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class UredjajConfiguration : IEntityTypeConfiguration<Uredjaj>
    {
        public void Configure(EntityTypeBuilder<Uredjaj> builder)
        {
            builder.HasData(
                new Uredjaj
                {
                    ID = 1,
                    Naziv = "Samsung Galaxy A71",
                    KategorijaID = 1
                },
                new Uredjaj
                {
                    ID = 2,
                    Naziv = "Samsung Galaxy Tab A lite",
                    KategorijaID = 2
                },
                new Uredjaj
                {
                    ID = 3,
                    Naziv = "Lenovo IdeaPad",
                    KategorijaID = 3
                },
                new Uredjaj
                {
                    ID = 4,
                    Naziv = "Gaming računar",
                    KategorijaID = 4
                },
                new Uredjaj
                {
                    ID = 5,
                    Naziv = "Samsung Galaxy S21",
                    KategorijaID = 1
                }
            );
        }
    }
}
