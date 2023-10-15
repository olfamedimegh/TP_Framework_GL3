using Microsoft.EntityFrameworkCore;

namespace TP_2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Movie>? movies { get; set; }
        public DbSet<Genre>? genres { get; set; }
    }
}
