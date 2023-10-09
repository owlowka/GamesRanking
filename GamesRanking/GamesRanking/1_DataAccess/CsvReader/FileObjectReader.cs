using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Serialization;

namespace GamesRanking.DataAccess.CsvReader;
public class FileObjectReader<TEntity> : IFileObjectReader<TEntity>
    where TEntity : class, IEntity
{
    private readonly ISerializer<List<TEntity>> _serializer;

    public FileObjectReader(ISerializer<List<TEntity>> serializer)
    {
        _serializer = serializer;
    }

    public List<TEntity> ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<TEntity>();
        }

        string fileContent = File.ReadAllText(filePath);
        return _serializer.Deserialize(fileContent);
    }
}


