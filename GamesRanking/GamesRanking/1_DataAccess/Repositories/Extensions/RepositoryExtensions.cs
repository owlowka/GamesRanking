using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Repositories;

namespace GamesRanking.DataAccess.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatch<TEntity>(this IRepository<TEntity> repository, TEntity[] items)
        where TEntity : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }

        repository.Save();
    }
}
