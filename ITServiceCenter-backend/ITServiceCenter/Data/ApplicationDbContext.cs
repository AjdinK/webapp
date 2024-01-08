using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <Grad> Grad { get; set; }
        public ApplicationDbContext (DbContextOptions options) : base (options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
