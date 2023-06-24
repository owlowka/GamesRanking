using GamesRanking.Repositories;
using GamesRanking.Entities;
using GamesRanking.Data;

var gameRepository = new SqlRepository<Game>(new GamesRankingDbContext());

AddGames(gameRepository);
AddVirtual(gameRepository);
AddAnalog(gameRepository);
WriteAllToConsole(gameRepository);

static void AddGames(IRepository<Game> gameRepository)
{
    gameRepository.Add(new Game { Name = "Tennis" });
    gameRepository.Add(new Game { Name = "Chess" });
    gameRepository.Add(new Game { Name = "Poker" });
    gameRepository.Save();
}

static void AddVirtual(IWriteRepository<Virtual> virtualRepository)
{
    virtualRepository.Add(new Virtual { Name = "Horizon" });
    virtualRepository.Add(new Virtual { Name = "Hogwarts Legacy" });
    virtualRepository.Add(new Virtual { Name = "Hunt" });
    virtualRepository.Save();
}

static void AddAnalog(IWriteRepository<Analog> analogRepository)
{
    analogRepository.Add(new Analog { Name = "Talisman" });
    analogRepository.Add(new Analog { Name = "Witcher" });
    analogRepository.Add(new Analog { Name = "ExitRoom" });
    analogRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

Console.ReadLine();