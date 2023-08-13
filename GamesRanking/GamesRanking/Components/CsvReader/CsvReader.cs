using GamesRanking.Components.CsvReader.Models;
using GamesRanking.Components.CsvReader.Extensions;

namespace GamesRanking.Components.CsvReader;
public class CsvReader : ICsvReader
{
    public List<Game> ProcessGames(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Game>();
        }

        var games = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 0)
            .ToGame()
            .ToList();

        games.ForEach(game =>
        {
            if (game is null)
            {
            }
        });

        return games;
    }

    public List<YearStats> ProcessPublishedYears(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<YearStats>();
        }

        var  years = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 0)
            .Select(x =>
            {
                var columns = x.Split(';');
                return new YearStats()
                {
                    Year = columns[0].FieldToInt(),

                    TotalAmount = columns[1].FieldToInt(),

                    Average = columns[2].FieldToDouble()
                };
            });

        return years.ToList();
    }
}
