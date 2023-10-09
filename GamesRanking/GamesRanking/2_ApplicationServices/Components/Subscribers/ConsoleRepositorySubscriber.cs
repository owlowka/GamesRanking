using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Repositories;

namespace GamesRanking.ApplicationServices.Components.Subscribers;
public class ConsoleRepositorySubscriber<TEntity> : RepositorySubscriberBase<TEntity>
    where TEntity : class, IEntity
{
    public ConsoleRepositorySubscriber(IRepository<TEntity> entityRepository)
        : base(entityRepository)
    {
    }

    protected override void HandleItemAdded(object? sender, TEntity e)
    {
        Console.WriteLine($"{EntityName} Added: {e} ");
    }

    protected override void HandleItemRemoved(object? sender, TEntity e)
    {
        Console.WriteLine($"{EntityName} Removed: {e} ");
    }

    protected override void HandleSaved(object? sender, EventArgs e)
    {
        Console.WriteLine($"Changes Saved: {e} ");
    }
}
