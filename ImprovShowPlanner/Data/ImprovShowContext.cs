using Microsoft.EntityFrameworkCore;

namespace ImprovShowPlanner.Data
{
    public class ImprovShowContext : DbContext
    {
        public ImprovShowContext(DbContextOptions<ImprovShowContext> options) : base(options)
        {
        }

        public DbSet<Models.Game> Games { get; set; }
        public DbSet<Models.GameType> GameTypes { get; set; }
        public DbSet<Models.IndivShow> IndivShows { get; set; }
        public DbSet<Models.Player> Players { get; set; }
        public DbSet<Models.Show> Shows { get; set; }
    }
}
