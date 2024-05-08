using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class Serviser_ServisniDioConfiguration : IEntityTypeConfiguration<Serviser_ServisniDio>
    {
        public void Configure(EntityTypeBuilder<Serviser_ServisniDio> builder)
        {
            builder.HasData(
                new Serviser_ServisniDio
                {
                    ServiserID = 2,
                    ServisniDioID = 1,
                    Kolicina = 3,
                    Datum = DateTime.Now
                },
                new Serviser_ServisniDio
                {
                    ServiserID = 2,
                    ServisniDioID = 2,
                    Kolicina = 3,
                    Datum = DateTime.Now
                },
                new Serviser_ServisniDio
                {
                    ServiserID = 2,
                    ServisniDioID = 3,
                    Kolicina = 2,
                    Datum = DateTime.Now
                },
                new Serviser_ServisniDio
                {
                    ServiserID = 2,
                    ServisniDioID = 4,
                    Kolicina = 1,
                    Datum = DateTime.Now
                }
            );
        }
    }
}
