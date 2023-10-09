using GamesRanking.Data.Entities;

namespace GamesRanking.DataAccess.Repositories
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity
    {
        public event EventHandler<TEntity>? ItemAdded;

        public event EventHandler<TEntity>? ItemRemoved;

        public event EventHandler? Saved;
    }
}
