using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Repositories;

namespace GamesRanking.ApplicationServices.Components.Subscribers;
public abstract class RepositorySubscriberBase<TEntity> : ISubscriber where TEntity : class, IEntity
{
    public static readonly string EntityName = typeof(TEntity).Name;

    private readonly IRepository<TEntity> _entityRepository;

    protected RepositorySubscriberBase(IRepository<TEntity> entityRepository)
    {
        _entityRepository = entityRepository;
    }

    public void Subscribe()
    {
        /*Na event Saved*/
        _entityRepository.Saved /*subskrybujemy się*/+= /*metodą*/HandleSaved;
        _entityRepository.ItemAdded += HandleItemAdded;
        _entityRepository.ItemRemoved += HandleItemRemoved;
    }

    protected abstract void HandleItemAdded(object? sender, TEntity e);
    protected abstract void HandleSaved(object? sender, EventArgs e);
    protected abstract void HandleItemRemoved(object? sender, TEntity e);
}