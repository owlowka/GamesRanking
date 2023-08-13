using GamesRanking.Components.CsvReader.Models;
using GamesRanking.Components.CsvReader;
using System.Security.Cryptography.X509Certificates;

namespace GamesRanking.App;
public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(
        ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        List<Game>? games = _csvReader.ProcessGames("C:\\repos\\GamesRanking\\GamesRanking\\GamesRanking\\Resources\\Files\\bgg_dataset.csv");
        List<YearStats>? years = _csvReader.ProcessPublishedYears("C:\\repos\\GamesRanking\\GamesRanking\\GamesRanking\\Resources\\Files\\game_data.csv");

        DisplayAgePlayersAndAvg(games);
        DisplayGamesByYearAndAverage(games, years);
        DisplayGamesByYearCountAndAvg(games, years);

    }

    private static void DisplayGamesByYearCountAndAvg(List<Game> games, List<YearStats> years)
    {
        var groups = years.GroupJoin(
            games,
            year => year.Year,
            game => game.YearPublished,
            (stats, games) =>
            new
            {
                Stats = stats,
                Games = games
            })
            .OrderBy(group => group.Stats.Year)
            .Take(100);

        foreach (var group in groups)
        {
            Console.WriteLine($"Year: {group.Stats.Year}");
            Console.WriteLine($"\t Games: {group.Games.Count()}");
            Console.WriteLine($"\t Avgs");
            Console.WriteLine($"\t Max: {group.Games.Max(x => x.ComplexityAverage)}");
            Console.WriteLine($"\t Min: {group.Games.Min(x => x.ComplexityAverage)}");
            Console.WriteLine($"\t Avg: {group.Games.Average(x => x.ComplexityAverage)}");
            Console.WriteLine();
        }
    }

    public static void DisplayAgePlayersAndAvg(List<Game>? games)
    {
        var groups = games
                    .GroupBy(group => group.MinPlayers)
                    .Select(games =>
                        new
                        {
                            Name = games.Key,
                            Min = games.Min(c => c.MinAge),
                            Avg = games.Max(c => c.ComplexityAverage),
                        })
                        .OrderBy(group => group.Min);

        foreach (var group in groups)
        {
            Console.WriteLine($"Min Players {group.Name}");
            Console.WriteLine($"\t Min Age {group.Min}");
            Console.WriteLine($"\t Avg {group.Avg}");
        }
    }

    private static void DisplayGamesByYearAndAverage(List<Game> games, List<YearStats> years)
    {
        var gamesAveragePerYear = games.Join(
            years,
            x => x.YearPublished,
            x => x.Year,
            (game, year) =>
                new
                {
                    game.Name,
                    game.YearPublished,
                    game.RatingAverage,
                    year.Average
                })
            .OrderBy(x => x.YearPublished)
            .ThenBy(x => x.Average)
            .ThenBy(x => x.RatingAverage);

        foreach (var game in gamesAveragePerYear)
        {
            Console.WriteLine($"Year: {game.YearPublished} AvgPerY: {game.Average}");
            Console.WriteLine($"Game Name: {game.Name} AvgGame {game.RatingAverage}");
            Console.WriteLine();
        }
    }
}
