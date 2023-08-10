using GamesRanking.Data.Entities;

namespace GamesRanking.Components.DataProviders
{
    public interface IGamesProvider
    {
        List<Game> GetAllGames();

        List<Game> GetAllGamesOfType(string type);

        List<Game> GetThreeTheBestGames();

        void AddGame(Game game);

        void RemoveByName(string name);

        void Save();

    }
}
