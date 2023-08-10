using GamesRanking.Components.Subscribers;
using GamesRanking.Data.Entities;
using GamesRanking.UserCommunication;

namespace GamesRanking.App;
public class App : IApp
{
    private readonly IViewManager _viewManager;
    private readonly AuditRepositorySubscriber<Game> _repositoryAuditSubscriber;
    private readonly ConsoleRepositorySubscriber<Game> _repositoryConsoleSubscriber;

    public App(
        IViewManager viewManager,
        AuditRepositorySubscriber<Game> repositoryAuditSubscriber,
        ConsoleRepositorySubscriber<Game> repositoryConsoleSubscriber)
    {
        _viewManager = viewManager;
        _repositoryAuditSubscriber = repositoryAuditSubscriber;
        _repositoryConsoleSubscriber = repositoryConsoleSubscriber;
    }

    public void Run()
    {
        _repositoryAuditSubscriber.Subscribe();

        _repositoryConsoleSubscriber.Subscribe();

        _viewManager.DisplayMenu();
    }
}
