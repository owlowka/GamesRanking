using Microsoft.Extensions.DependencyInjection;
using GamesRanking.DataAccess.Configuration;
using GamesRanking.UI;
using GamesRanking.DataAccess.Repositories;
using GamesRanking.ApplicationServices.Components.Subscribers;
using Microsoft.EntityFrameworkCore;
using GamesRanking.DataAccess;
using GamesRanking.DataAccess.CsvReader;
using GamesRanking.DataAccess.Serialization;
using GamesRanking.Data.Entities;
using GamesRanking.UI.Views;

DependencyInjection();
static void DependencyInjection()
{
    ServiceCollection? services = new ServiceCollection();
    //Register
    services.AddSingleton<ISubscriber, ConsoleRepositorySubscriber<Game>>();
    services.AddSingleton<ISubscriber, AuditRepositorySubscriber<Game>>();
    services.AddSingleton(new FileRepositoryOptions());
    services.AddSingleton(typeof(IRepository<>), typeof(SqlRepository<>));
    services.AddSingleton(typeof(IFileObjectReader<>), typeof(FileObjectReader<>));
    services.AddSingleton<ISerializer<List<Game>>, GameCsvSerializer>();
    services.AddSingleton<IViewManager, ConsoleViewManager>();
    services.AddSingleton<IApp, App>();

    string dbPath = "./games-ranking.db";

    services.AddDbContext<DbContext, GamesRankingDbContext>(database =>
    {
        database.UseSqlite($"Data Source={dbPath}");
        database.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Warning);
    });

    //Build
    ServiceProvider serviceProvider = services.BuildServiceProvider();

    InitializeDatabase(serviceProvider);

    //Resolve
    IApp app = serviceProvider.GetRequiredService<IApp>();
    app.Run();

}

static void InitializeDatabase(ServiceProvider serviceProvider)
{
    using (IServiceScope scope = serviceProvider.CreateScope())
    {
        GamesRankingDbContext dbContext = scope.ServiceProvider
            .GetRequiredService<GamesRankingDbContext>();

        dbContext.Database.EnsureCreated();
    }
}