using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class Prodavac_UredfjajConfiguration : IEntityTypeConfiguration<Prodavac_Uredjaj>
    {
        public void Configure(EntityTypeBuilder<Prodavac_Uredjaj> builder)
        {
            builder.HasData(
                new Prodavac_Uredjaj
                {
                    ProdavacID= 4,
                    UredjajID = 1,
                    ServisniNalogID = 1,
                    RacunID = 1,
                },
                  new Prodavac_Uredjaj
                  {
                      ProdavacID = 4,
                      UredjajID = 2,
                      ServisniNalogID = 2,
                      RacunID = null
                  },
                    new Prodavac_Uredjaj
                    {
                        ProdavacID = 4,
                        UredjajID = 3,
                        ServisniNalogID = 3,
                        RacunID = null
                    },
                      new Prodavac_Uredjaj
                      {
                          ProdavacID = 5,
                          UredjajID = 4,
                          ServisniNalogID = 4,
                          RacunID = null
                      },
                        new Prodavac_Uredjaj
                        {
                            ProdavacID = 5,
                            UredjajID = 5,
                            ServisniNalogID = 5,
                            RacunID = null
                        }
                );
        }
    }
}
