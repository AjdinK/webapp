using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class KategorijaConfiguration : IEntityTypeConfiguration<Kategorija>
    {
        public void Configure(EntityTypeBuilder<Kategorija> builder)
        {
            builder.HasData(new Kategorija { ID = 1, Naziv = "Mobitel"},
                            new Kategorija { ID = 2, Naziv = "Tablet" },
                            new Kategorija { ID = 3, Naziv = "Laptop" },
                            new Kategorija { ID = 4, Naziv = "Računar" });
        }
    }
}
