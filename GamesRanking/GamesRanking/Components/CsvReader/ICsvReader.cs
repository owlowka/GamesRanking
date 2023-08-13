using GamesRanking.Components.CsvReader.Models;

namespace GamesRanking.Components.CsvReader;
public interface ICsvReader
{
    List<Game> ProcessGames(string filePath);

    List<YearStats> ProcessPublishedYears(string filePath);


}
