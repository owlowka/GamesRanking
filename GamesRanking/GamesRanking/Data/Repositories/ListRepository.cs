using GamesRanking.Data.Entities;

namespace GamesRanking.Data.Repositories
{
    public class ListRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity, new()

    {
        private readonly List<TEntity> _items = new();

        override public IEnumerable<TEntity> GetAll()
        {
            return _items.ToList();
        }
        protected override int GetNextId()
        {
            return _items.Count + 1;
        }

        override public void Add(TEntity item)
        {
            _items.Add(item);
            OnItemAdded(item);
        }

        override public void Remove(TEntity item)
        {
            _items.Remove(item);
        }

        override public void Save()
        {

        }

        override public TEntity GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
    }
}