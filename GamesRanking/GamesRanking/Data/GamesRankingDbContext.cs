using Microsoft.EntityFrameworkCore;
using GamesRanking.Entities;

namespace GamesRanking.Data
{
    public class GamesRankingDbContext : DbContext
    {
        public DbSet<Game> Games => Set<Game>();

        //public DbSet<Analog> AnalogGames => Set<Analog>();

        //public DbSet<Virtual> VirtuaGames => Set<Virtual>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
