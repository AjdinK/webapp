using itservicecenter.Configuration;
using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (
                var relationship in modelBuilder
                    .Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys())
            )
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder
                .Entity<Prodavac_Uredjaj>()
                .HasKey(x => new
                {
                    x.ProdavacID,
                    x.UredjajID,
                    x.ServisniNalogID
                });
            modelBuilder
                .Entity<Serviser_Kategorija>()
                .HasKey(x => new { x.ServiserID, x.KategorijaID });
            modelBuilder
                .Entity<Serviser_ServisniDio>()
                .HasKey(x => new
                {
                    x.ServiserID,
                    x.ServisniDioID,
                    x.Datum
                });
            modelBuilder.Entity<Serviser_Uredjaj>().HasKey(x => new { x.ServiserID, x.UredjajID });

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new FAQConfiguration());
            modelBuilder.ApplyConfiguration(new GradConfiguration());
            modelBuilder.ApplyConfiguration(new KategorijaConfiguration());
            modelBuilder.ApplyConfiguration(new Prodavac_UredfjajConfiguration());
            modelBuilder.ApplyConfiguration(new ProdavacConfiguration());
            modelBuilder.ApplyConfiguration(new ProizvodjacConfiguration());
            modelBuilder.ApplyConfiguration(new RacunConfiguration());
            modelBuilder.ApplyConfiguration(new ServiserConfiguration());
            modelBuilder.ApplyConfiguration(new Serviser_KategorijaConfiguration());
            modelBuilder.ApplyConfiguration(new Serviser_ServisniDioConfiguration());
            modelBuilder.ApplyConfiguration(new Serviser_UredjajConfiguration());
            modelBuilder.ApplyConfiguration(new ServisniDioConfiguration());
            modelBuilder.ApplyConfiguration(new ServisniNalogConfiguration());
            modelBuilder.ApplyConfiguration(new SpolConfiguration());
            modelBuilder.ApplyConfiguration(new UredjajConfiguration());
            modelBuilder.ApplyConfiguration(new VrstaDioConfiguration());
        }

        public DbSet<Grad> Grad { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AutenfitikacijaToken> AutenfitikacijaToken { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
        public DbSet<Prodavac> Prodavac { get; set; }
        public DbSet<Uredjaj> Uredjaj { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Serviser> Serviser { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<VrstaDio> VrstaDio { get; set; }
        public DbSet<Prodavac_Uredjaj> Prodavac_Uredjaj { get; set; }
        public DbSet<ServisniNalog> ServisniNalog { get; set; }
        public DbSet<Serviser_Uredjaj> Serviser_Uredjaj { get; set; }
        public DbSet<ServisniDio> ServisniDio { get; set; }
        public DbSet<Serviser_ServisniDio> Serviser_ServisniDio { get; set; }
        public DbSet<Serviser_Kategorija> Serviser_Kategorija { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
    }
}
