
namespace GamesRanking.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using GamesRanking.Entities;
    public class SqlRepository<TEntity>: IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly DbContext _dbContext;

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
