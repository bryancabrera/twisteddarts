using TwistedDarts.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace TwistedDarts.DAL
{
    public class TwistedDartsContext : DbContext

    {
        public TwistedDartsContext() : base("TwistedDartsContext") { }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Address> Addresses { get; set; }
        //public DbSet<GamePlayer> MatchGames { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchSet> MatchSets { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<AllStarPoint> AllStarPoints { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ScheduleDate> ScheduleDate { get; set; }
        public DbSet<PlayerPhase> PlayerPhase { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Match>()
                .HasRequired(e => e.Establishment)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Match>()
                .HasRequired(ht => ht.HomeTeam)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Match>()
                .HasRequired(at => at.AwayTeam)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchSet>()
                .HasRequired(m => m.Match)
                .WithMany(ms => ms.MatchSets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameResult>()
                .HasRequired(t => t.SubmissionTeam)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<GameResult>()
               .HasRequired(p => p.PlayerPhase)
               .WithRequiredPrincipal();

            modelBuilder.Entity<GameResult>()
                .HasRequired(p => p.PlayerPhase)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PlayerPhase>()
                .HasRequired(s => s.Season)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PlayerPhase>()
                .HasRequired(t => t.Team)
                .WithMany(p => p.PlayerPhase)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Person>()
                .HasMany(a => a.Addresses)
                .WithMany(p => p.People);
            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.Season)
                .WithMany()
                .WillCascadeOnDelete(false);

            //. .WillCascadeOnDelete(false);

            //modelBuilder.Entity<GameResult>()

            //modelBuilder.Entity<Person>()
            //    .HasOptional(a => a.AllStarPoints)
            //    .WithOptionalPrincipal();

            //modelBuilder.Entity<AllStarPoint>()
            //    .HasRequired(p => p.PlayerPhase)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<GameResult>()
            //    .HasOptional(ap => ap.AllStarPoints)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<ScheduleDate>().HasKey(t => new { t.ScheduleID, t.GameDate });
        }
    }

}