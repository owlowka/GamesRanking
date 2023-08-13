using GamesRanking.Components.CsvReader.Models;

namespace GamesRanking.Components.CsvReader.Extensions;
public static class GameExtensions
{
    public static IEnumerable<Game> ToGame(this IEnumerable<string> source)
    {
        return source
            .Select(line =>
            {
                string[] columns = line.Trim().Split(';');

                int? id = columns[0].FieldToInt();

                if (id is null)
                {
                    return null;
                }

                string? name = columns[1].FieldToString();

                int? yearPublished = columns[2].FieldToInt();

                int? minPlayers = columns[3].FieldToInt();

                int? maxPlayers = columns[4].FieldToInt();

                int? playTime = columns[5].FieldToInt();

                int? minAge = columns[6].FieldToInt();

                double? usersRated = columns[7].FieldToDouble();

                double? ratingAverage = columns[8].FieldToDouble();

                double? bggRank = columns[9].FieldToDouble();

                double? complexityAverage = columns[10].FieldToDouble();

                int? ownedUsers = columns[11].FieldToInt();

                string[]? mechanics = columns[12].FieldToStringArray();

                string[]? domains = columns[13].FieldToStringArray();


                var game = new Game
                {
                    Id = id.Value,

                    Name = name,

                    YearPublished = yearPublished,

                    MinPlayers = minPlayers,

                    MaxPlayers = maxPlayers,

                    PlayTime = playTime,

                    MinAge = minAge,

                    UsersRated = usersRated,

                    RatingAverage = ratingAverage,

                    BggRank = bggRank,

                    ComplexityAverage = complexityAverage,

                    OwnedUsers = ownedUsers,

                    Mechanics = mechanics,

                    Domains = domains
                };

                return game;
            })
            .OfType<Game>();
    }
}
