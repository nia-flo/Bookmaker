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
            //koi server da izpolzva
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationData.ConnectionString).UseLazyLoadingProxies();
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchTeam>()
                .HasKey(mt => new { mt.MatchId, mt.TeamId });
            modelBuilder.Entity<MatchTeam>()
                .HasOne(mt => mt.Match)
                .WithMany(b => b.MatchTeams)
                .HasForeignKey(mt => mt.TeamId);
            modelBuilder.Entity<MatchTeam>()
                .HasOne(bc => bc.Team)
                .WithMany(c => c.MatchTeams)
                .HasForeignKey(bc => bc.MatchId);
        }
    }
}