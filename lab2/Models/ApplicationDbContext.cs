using Microsoft.EntityFrameworkCore;

namespace lab2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GasStation> GasStation => Set<GasStation>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
