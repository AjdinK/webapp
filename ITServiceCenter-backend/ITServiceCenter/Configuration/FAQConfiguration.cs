using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace itservicecenter.Configuration
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.HasData(
                new FAQ
                {
                    ID = 1,
                    Pitanje = "Koja je cijena servisa?",
                    Odgovor = "Cijena servisa se određuje u odnosu na model i kvar uređaja."
                },
                new FAQ
                {
                    ID = 2,
                    Pitanje = "Kada će moj telefon biti završen?",
                    Odgovor =
                        "Vrijeme završetka servisa se određuje u trenutku kada se uređaj ostavlja na servis. Količina servisa, vrsta kvara, vrijeme ostavljanja servisa su neki od parametra koju utječu kada će vaš servis biti završen."
                },
                new FAQ
                {
                    ID = 3,
                    Pitanje = "Kada se plaća servis?",
                    Odgovor = "Servis se plaća pri preuzimanju uređaja iz poslovnice."
                }
            );
        }
    }
}
