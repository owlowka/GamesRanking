using GamesRanking.Data;
using GamesRanking.Entities;

namespace GamesRanking.Repositories
{
    public interface IReadRepository<out TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

    }
}
