using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class ServisniDioConfiguration : IEntityTypeConfiguration<ServisniDio>
    {
        public void Configure(EntityTypeBuilder<ServisniDio> builder)
        {
            builder.HasData(
                new ServisniDio
                {
                    ID = 1,
                    ProizvodjacID = 1,
                    VrstaDioID = 1,
                    Cijena = 100,
                    Naziv = "Sasmung Galaxy A71"
                },
                  new ServisniDio
                  {
                      ID = 2,
                      ProizvodjacID = 1,
                      VrstaDioID = 2,
                      Cijena = 50,
                      Naziv = "Sasmung Galaxy A71"
                  },
                    new ServisniDio
                    {
                        ID = 3,
                        ProizvodjacID = 2,
                        VrstaDioID = 1,
                        Cijena = 220,
                        Naziv = "Iphone 11 pro max 1klasa"
                    },
                      new ServisniDio
                      {
                          ID = 4,
                          ProizvodjacID = 1,
                          VrstaDioID = 3,
                          Cijena = 50,
                          Naziv = "Sasmung Galaxy A71"
                      }
                );
        }
    }
}
