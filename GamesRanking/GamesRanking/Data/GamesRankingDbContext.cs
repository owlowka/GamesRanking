using Microsoft.EntityFrameworkCore;
using GamesRanking.Data.Entities;

namespace GamesRanking.Data
{
    public class GamesRankingDbContext : DbContext
    {
        public DbSet<Game> Games => Set<Game>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
