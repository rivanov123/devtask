using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TeamRankings.DomainModel;

namespace TeamRankings.DataAccess
{
    public class TeamRankingsDbContext : DbContext
    {
        public TeamRankingsDbContext (string connectionString) : base(connectionString)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<TeamMatchScore> TeamMatchScores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
