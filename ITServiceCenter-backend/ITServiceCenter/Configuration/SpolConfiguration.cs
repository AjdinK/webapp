using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class SpolConfiguration : IEntityTypeConfiguration<Spol>
    {
        public void Configure(EntityTypeBuilder<Spol> builder)
        {
            builder.HasData(
                new Spol
                {
                    ID = 1,
                    Naziv = "Muški",
                },
                new Spol
                {
                    ID = 2,
                    Naziv = "Ženski",
                });

        }
    }
}
