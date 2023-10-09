using GamesRanking.Data.Entities;
using System.Text.Json;

namespace GamesRanking.DataAccess.Serialization;
public class JsonSerializer<TEntity> : ISerializer<TEntity>
{
    public TEntity Deserialize(string json)
    {
        TEntity entity = JsonSerializer.Deserialize<TEntity>(json);
        return entity;
    }

    public string Serialize(TEntity entity)
    {
        string json = JsonSerializer.Serialize(entity);
        return json;
    }
}
