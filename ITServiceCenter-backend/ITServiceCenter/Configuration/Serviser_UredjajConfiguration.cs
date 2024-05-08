using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class Serviser_UredjajConfiguration : IEntityTypeConfiguration<Serviser_Uredjaj>
    {
        public void Configure(EntityTypeBuilder<Serviser_Uredjaj> builder)
        {
            builder.HasData(
                new Serviser_Uredjaj
                {
                    ID = 1,
                    Status = "Završen uredja",
                    Popravljeno = true,
                    ServiserID = 2,
                    UredjajID = 1,
                },
                new Serviser_Uredjaj
                {
                    ID = 2,
                    Status = "Radi se",
                    Popravljeno = false,
                    ServiserID = 2,
                    UredjajID = 2,
                },
                new Serviser_Uredjaj
                {
                    ID = 3,
                    Status = "Ceka dio",
                    Popravljeno = false,
                    ServiserID = 2,
                    UredjajID = 5,
                },
                new Serviser_Uredjaj
                {
                    ID = 4,
                    Status = "Radi se sistem...",
                    Popravljeno = false,
                    ServiserID = 3,
                    UredjajID = 3,
                },
                new Serviser_Uredjaj
                {
                    ID = 5,
                    Status = "Analiza",
                    Popravljeno = false,
                    ServiserID = 2,
                    UredjajID = 4,
                }
            );
        }
    }
}
