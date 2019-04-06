using Bookmaker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmaker.Data
{
    /*
        The BookmakerContext class
        Contains all DBSets and setting for server configuring and model creating
    */
    /// <summary>
    /// The <c>BookmakerContext</c> class.
    /// Contains all DBSets and setting for server configuring and model creating.
    /// </summary>
    public class BookmakerContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Coach> Coaches { get; set; }

        public virtual DbSet<Injury> Injuries { get; set; }

        public virtual DbSet<Match> Matches { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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