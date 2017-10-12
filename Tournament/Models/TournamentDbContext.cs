using System.Data.Entity;

namespace Tournament.Models
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext() : base("TournamentDbContext") { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}