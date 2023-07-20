
//namespace GamesRanking.Repositories
//{
//    using Microsoft.EntityFrameworkCore;
//    using GamesRanking.Entities;

//    public class SqlRepository<TEntity>: RepositoryBase<TEntity> where TEntity : class, IEntity, new()
//    {
//        private readonly DbSet<TEntity> _dbSet;
//        private readonly DbContext _dbContext;
//        private readonly Action<TEntity>? _itemAddedCallback;

//        public SqlRepository(DbContext dbContext, Action<TEntity>? itemAddedCallback = null)
//        {
//            _dbContext = dbContext;
//            _dbSet = _dbContext.Set<TEntity>();
//            _itemAddedCallback = itemAddedCallback;
//        }
//        override public IEnumerable<TEntity> GetAll()
//        {
//            return _dbSet.OrderBy(item => item.Id).ToList();
//        }

//        override public TEntity? GetById(int id)
//        {
//            return _dbSet.Find(id);
//        }

//        protected override int GetNextId()
//        {
//            return _dbSet.Count() + 1;
//        }
//        override public void Add(TEntity item)
//        {
//            _dbSet.Add(item);
//            _itemAddedCallback?.Invoke(item);
//            OnItemAdded(item);
//        }

//        override public void Remove(TEntity item)
//        {
//            _dbSet.Remove(item);
//        }

//        override public void Save()
//        {
//            _dbContext.SaveChanges();
//        }
//    }
//}
