using Microsoft.EntityFrameworkCore;

namespace lab1.Models
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
