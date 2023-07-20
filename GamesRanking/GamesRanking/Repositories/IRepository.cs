using GamesRanking.Data;
using GamesRanking.Entities;

namespace GamesRanking.Repositories
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
        public event EventHandler<TEntity>? ItemAdded;

        public event EventHandler? Saved;

    }
}
