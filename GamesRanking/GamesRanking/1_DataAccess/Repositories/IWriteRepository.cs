using GamesRanking.Data;
using GamesRanking.Data.Entities;

namespace GamesRanking.DataAccess.Repositories
{
    public interface IWriteRepository<in TEntity>
        where TEntity : class, IEntity
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Save();

    }
}
