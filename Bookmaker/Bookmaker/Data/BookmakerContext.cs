using Bookmaker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmaker.Data
{
    public class BookmakerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Injury> Injuries { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}