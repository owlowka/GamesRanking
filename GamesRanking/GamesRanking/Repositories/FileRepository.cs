using GamesRanking.Entities;
using System.Text.Json;

namespace GamesRanking.Repositories
{
    public class FileRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly string _fileName;
        private readonly List<TEntity> _items = new();

        public FileRepository(string fileName)
        {
            _fileName = fileName;
            _items = this.ReadEntitiesFromFile();
        }
        private List<TEntity> ReadEntitiesFromFile()
        {
            //if (File.Exists(_fileName))
            //{
            //    string json1 = File.ReadAllText(_fileName);
            //    return JsonSerializer.Deserialize<List<TEntity>>(json1) ?? new List<TEntity>();
            //}

            if (File.Exists(_fileName))
            {
                using (StreamReader reader = File.OpenText(_fileName))
                {
                    string json = reader.ReadToEnd();

                    return JsonSerializer.Deserialize<List<TEntity>>(json) ?? new List<TEntity>();
                }
            }

            return new List<TEntity>();
        }

        override public IEnumerable<TEntity> GetAll()
        {
            return _items.ToList();
        }
        protected override int GetNextId()
        {
            return _items.Count;
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
            //File.WriteAllText(_fileName, JsonSerializer.Serialize(_items));

            using (StreamWriter writer = File.CreateText(_fileName))
            {
                string json = JsonSerializer.Serialize(_items);

                writer.Write(json);
            }
            OnSaved();
        }

        override public TEntity GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
    }
}