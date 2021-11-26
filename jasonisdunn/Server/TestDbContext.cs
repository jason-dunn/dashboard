using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using dashboard.Shared;

namespace dashboard.Server
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Raw> Raw { get; set; }
        public DbSet<Miner> Miner { get; set; }
        public DbSet<Yeild> Yeild { get; set; }
        

    }
}