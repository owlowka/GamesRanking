namespace GamesRanking.DataAccess.CsvReader;
public interface IFileObjectReader<TEntity>
{
    List<TEntity> ReadFile(string filePath);
}
