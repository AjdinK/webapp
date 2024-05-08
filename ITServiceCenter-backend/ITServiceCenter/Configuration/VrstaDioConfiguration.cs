using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class VrstaDioConfiguration : IEntityTypeConfiguration<VrstaDio>
    {
        public void Configure(EntityTypeBuilder<VrstaDio> builder)
        {
            builder.HasData(
                new VrstaDio { ID = 1, Naziv = "LCD" },
                new VrstaDio { ID = 2, Naziv = "Baterija" },
                new VrstaDio { ID = 3, Naziv = "Pločica punjenja" }
            );
        }
    }
}
