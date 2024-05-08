using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class Serviser_KategorijaConfiguration : IEntityTypeConfiguration<Serviser_Kategorija>
    {
        public void Configure(EntityTypeBuilder<Serviser_Kategorija> builder)
        {
            builder.HasData(
                new Serviser_Kategorija { ServiserID = 2, KategorijaID = 1 },
                new Serviser_Kategorija { ServiserID = 2, KategorijaID = 2 },
                new Serviser_Kategorija { ServiserID = 3, KategorijaID = 3 },
                new Serviser_Kategorija { ServiserID = 3, KategorijaID = 4 }
            );
        }
    }
}
