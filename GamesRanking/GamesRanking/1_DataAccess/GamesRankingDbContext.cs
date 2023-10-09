using Microsoft.EntityFrameworkCore;
using GamesRanking.Data.Entities;

namespace GamesRanking.DataAccess
{
    public class GamesRankingDbContext : DbContext
    {
        public GamesRankingDbContext(DbContextOptions<GamesRankingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();
        public DbSet<Audit> Audits => Set<Audit>();
    }
}
