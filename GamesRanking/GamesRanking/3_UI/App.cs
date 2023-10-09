using GamesRanking.DataAccess.CsvReader;
using GamesRanking.Data.Entities;
using GamesRanking.DataAccess;
using GamesRanking.UI.Views;
using GamesRanking.ApplicationServices.Components.Subscribers;

namespace GamesRanking.UI;
public class App : IApp
{
    private readonly IFileObjectReader<Game> _gameReader;
    private readonly GamesRankingDbContext _gamesRankingDbContext;
    private readonly IViewManager _viewManager;
    private readonly IEnumerable<ISubscriber> _subscribers;

    public App(
        IFileObjectReader<Game> gameReader,
        GamesRankingDbContext gamesRankingDbContext,
        IViewManager viewManager,
        IEnumerable<ISubscriber> subscribers)
    {
        _gameReader = gameReader;
        _gamesRankingDbContext = gamesRankingDbContext;
        _viewManager = viewManager;
        _subscribers = subscribers;
    }

    public void Run()
    {
        Subscribe();
        //InsertData();

        _viewManager.DisplayMenu(); //have to be the last method called here because it's waiting for user input
    }

    private void Subscribe()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.Subscribe();
        }
    }

    private void InsertData()
    {
        List<Game>? games = _gameReader.ReadFile(filePath: @"1_DataAccess\Resources\Files\bgg_dataset.csv");

        foreach (Game game in games)
        {
            _gamesRankingDbContext.Games.Add(new Game()
            {
                //Id = game.Id,
                Name = game.Name,
                YearPublished = game.YearPublished,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
                PlayTime = game.PlayTime,
                MinAge = game.MinAge,
                UsersRated = game.UsersRated,
                RatingAverage = game.RatingAverage,
                BggRank = game.BggRank,
                ComplexityAverage = game.ComplexityAverage,
                OwnedUsers = game.OwnedUsers,
                Mechanics = game.Mechanics,
                Domains = game.Domains,

            });
        }
        _gamesRankingDbContext.SaveChanges();
    }
}
