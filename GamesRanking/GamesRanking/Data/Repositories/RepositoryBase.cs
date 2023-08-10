using GamesRanking.Data.Entities;

namespace GamesRanking.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public event EventHandler<TEntity>? ItemAdded;

        public event EventHandler<TEntity>? ItemRemoved;

        public event EventHandler? Saved;

        protected virtual void OnItemAdded(TEntity entity)
        {
            entity.Id ??= GetNextId();
            ItemAdded?.Invoke(this, entity);
        }

        protected virtual void OnItemRemoved(TEntity item)
        {
            ItemRemoved?.Invoke(this, item);
        }

        protected virtual void OnSaved()
        {
            Saved?.Invoke(this, EventArgs.Empty);
        }

        protected abstract int GetNextId();

        public abstract void Add(TEntity item);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TEntity GetById(int id);
        public abstract void Remove(TEntity item);
        public abstract void Save();

    }
}