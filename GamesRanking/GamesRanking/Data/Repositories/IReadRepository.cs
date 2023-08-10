using GamesRanking.Data;
using GamesRanking.Data.Entities;

namespace GamesRanking.Data.Repositories
{
    public interface IReadRepository<out TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

    }
}
