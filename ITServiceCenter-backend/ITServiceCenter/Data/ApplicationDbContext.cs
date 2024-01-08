using itservicecenter.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace itservicecenter.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
