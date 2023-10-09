using System.Text.Json;
using GamesRanking.DataAccess.CsvReader;
using GamesRanking.DataAccess.Configuration;
using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Serialization;

namespace GamesRanking.DataAccess.Repositories
{
    public class FileRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly FileInfo _repositoryFile;

        private readonly List<TEntity> _items = new();

        private readonly FileRepositoryOptions _options;

        private readonly ISerializer<TEntity> _fileObjectReader;


        public FileRepository(
            FileRepositoryOptions options,
            ISerializer<TEntity> fileObjectReader //zamienic na iSerializer
            )
        {
            _options = options;

            _repositoryFile = new FileInfo(
                Path.Combine(
                    options.FileDirectory.FullName,
                    $"{typeof(TEntity).Name}Repository.csv"));

            if (!_repositoryFile.Exists)
            {
                _repositoryFile.Create();
            }

            _fileObjectReader = fileObjectReader;


            _items = ReadEntitiesFromFile();
        }

        private List<TEntity> ReadEntitiesFromFile()
        {

            if (_repositoryFile.Exists)
            {
                using (StreamReader reader = _repositoryFile.OpenText())
                {
                    string json = reader.ReadToEnd();

                    if (!string.IsNullOrEmpty(json))
                    {
                        return JsonSerializer.Deserialize<List<TEntity>>(json) ?? new List<TEntity>();
                    }
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
            return _items.Count + 1;
        }

        override public void Add(TEntity item)
        {
            _items.Add(item);
            OnItemAdded(item);
        }

        override public void Remove(TEntity item)
        {
            if (_items.Remove(item))
            {
                OnItemRemoved(item);
            }
        }

        override public void Save()
        {

            using (StreamWriter writer = _repositoryFile.CreateText())
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