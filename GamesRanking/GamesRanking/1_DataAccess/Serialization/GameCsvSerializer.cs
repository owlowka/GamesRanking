using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.CsvReader.Extensions;

namespace GamesRanking.DataAccess.Serialization;
public class GameCsvSerializer : ISerializer<List<Game>>
{
    public List<Game> Deserialize(string text)
    {
        string[] lines = text.Split(Environment.NewLine);

        List<Game>? games = lines
            .Skip(1)
            .Where(line => line.Length > 0)
            .ToGames()
            .ToList();

        return games;

    }

    public string Serialize(List<Game> list)
    {
        var lines = list.Select(game =>
        {
            var properties =
               new object[]
               {
                   game.Id,
                   game.Name,
                   game.YearPublished,
                   game.MinPlayers,
                   game.MaxPlayers,
                   game.PlayTime,
                   game.MinAge,
                   game.UsersRated,
                   game.RatingAverage,
                   game.BggRank,
                   game.ComplexityAverage,
                   game.OwnedUsers,
                   game.Mechanics,
                   game.Domains
               };

            return String.Join(";", properties);
        });

        return String.Join(Environment.NewLine, lines);
    }
}
