using GamesRanking.Data.Entities;
using GamesRanking.Data.Repositories;

namespace GamesRanking.Components.Subscribers;
public class ConsoleRepositorySubscriber<TEntity> : RepositorySubscriberBase<TEntity>
    where TEntity : class, IEntity
{
    public ConsoleRepositorySubscriber(IRepository<TEntity> entityRepository)
        : base(entityRepository)
    {

    }

    protected override void HandleItemAdded(object? sender, TEntity e)
    {
        Console.WriteLine($"{EntityName} Added: {e.Id} ");
    }

    protected override void HandleItemRemoved(object? sender, TEntity e)
    {
        Console.WriteLine($"{EntityName} Removed: {e.Id} ");

    }

    protected override void HandleSaved(object? sender, EventArgs e)
    {
        Console.WriteLine($"Changes Saved: {e.ToString} ");
    }
}
