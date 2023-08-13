namespace GamesRanking.Components.CsvReader.Models;
public class Game
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? YearPublished { get; set; }

    public int? MinPlayers { get; set; }

    public int? MaxPlayers { get; set; }

    public int? PlayTime { get; set; }

    public int? MinAge { get; set; }

    public double? UsersRated { get; set; }

    public double? RatingAverage { get; set; }

    public double? BggRank { get; set; }

    public double? ComplexityAverage { get; set;}

    public int? OwnedUsers { get; set; }

    public string[]? Mechanics { get; set; }

    public string[]? Domains { get; set; }

}
