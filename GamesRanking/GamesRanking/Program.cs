using Microsoft.Extensions.DependencyInjection;
using GamesRanking.Configuration;
using GamesRanking.App;
using GamesRanking.Components.DataProviders;
using GamesRanking.Data.Repositories;
using GamesRanking.UserCommunication;
using GamesRanking.Components.Subscribers;
using GamesRanking.Components.CsvReader;

DependencyInjection();

static void DependencyInjection()
{
    var services = new ServiceCollection();
    //Register
    services.AddSingleton(typeof(ConsoleRepositorySubscriber<>));
    services.AddSingleton(typeof(AuditRepositorySubscriber<>));
    services.AddSingleton(new FileRepositoryOptions());
    services.AddSingleton(typeof(IRepository<>), typeof(FileRepository<>));
    services.AddSingleton<IGamesProvider, GamesProvider>();
    services.AddSingleton<ICsvReader, CsvReader>();
    services.AddSingleton<IApp, App>();
    services.AddSingleton<IViewManager, ConsoleViewManager>();

    //Build
    var serviceProvider = services.BuildServiceProvider();

    //Resolve
    var app = serviceProvider.GetService<IApp>();
    app.Run();

}

