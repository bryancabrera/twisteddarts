using TwistedDarts.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace TwistedDarts.DAL
{
    public class TwistedDartsContext : DbContext

    {
        public TwistedDartsContext() : base("TwistedDartsContext") { }
        public DbSet<Person> People { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchSet> MatchSets { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<AllStarPoint> AllStarPoints { get; set; }
        public DbSet<Establishment> Establishments { get; set; }

    }
}