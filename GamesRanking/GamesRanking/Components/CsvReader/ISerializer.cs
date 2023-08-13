namespace GamesRanking
{
    public interface ISerializer<T>
    {
        T Deserialize(string text);
        string Serialize(T @object);
    }
}
