using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class MigrateDBContext : DbContext
    {
        public MigrateDBContext(DbContextOptions<MigrateDBContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
