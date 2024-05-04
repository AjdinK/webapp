using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ProizvodjacConfiguration : IEntityTypeConfiguration<Proizvodjac>
    {
        public void Configure(EntityTypeBuilder<Proizvodjac> builder)
        {
            builder.HasData(
                new Proizvodjac { 
                    ID = 1, 
                    Naziv = "Samsung"
                },
                new Proizvodjac { 
                    ID = 2, 
                    Naziv = "Apple"
                },
                new Proizvodjac { 
                    ID = 3, 
                    Naziv = "Xiaomi"
                });
        }
    }
}
