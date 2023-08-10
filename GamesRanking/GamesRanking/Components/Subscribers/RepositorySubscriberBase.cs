using GamesRanking.Data.Entities;
using GamesRanking.Data.Repositories;

namespace GamesRanking.Components.Subscribers;
public abstract class RepositorySubscriberBase<TEntity> where TEntity : class, IEntity
{
    public static readonly string EntityName = typeof(TEntity).Name;

    private readonly IRepository<TEntity> _entityRepository;

    protected RepositorySubscriberBase(IRepository<TEntity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public void Subscribe()
    {
        _entityRepository.Saved += HandleSaved;
        _entityRepository.ItemAdded += HandleItemAdded;
        _entityRepository.ItemRemoved += HandleItemRemoved;
    }

    protected abstract void HandleItemAdded(object? sender, TEntity e);
    protected abstract void HandleSaved(object? sender, EventArgs e);
    protected abstract void HandleItemRemoved(object? sender, TEntity e);
}