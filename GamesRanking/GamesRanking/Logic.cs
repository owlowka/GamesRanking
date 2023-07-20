using GamesRanking.Repositories;
using GamesRanking.Entities;

public class Logic
{
    public static void SelectAction(char menuCharacter, IRepository<Game>  gameRepository)
    {
        switch (menuCharacter)
        {
            case '1':
                Console.WriteLine($" All games ranking ");
                WriteAllToConsole(gameRepository);
                DisplayShortMenu();

                break;
            case '2':
                Console.WriteLine($" Analog games ranking ");
                WriteAllToConsole(gameRepository);
                DisplayShortMenu();
                break;
            case '3':
                Console.WriteLine($" Virtual games ranking ");
                WriteAllToConsole(gameRepository);
                DisplayShortMenu();
                break;
            case '+':
                Game game = GetGameDetails();
                gameRepository.Add(game);
                DisplayShortMenu();
                break;
            case '-':
                //RemoveGame();
                DisplayShortMenu();
                break;
            case 's':
                Console.WriteLine($" Changes saved ");
                gameRepository.Save();
                DisplayShortMenu();
                break;
            case 'q':
                Console.Clear();
                Console.WriteLine($"Quit");
                Console.WriteLine($"|-------------------------THANK'S FOR VOTING-----------------------|");
                break;
        }
    }

    public static Game GetGameDetails()
    {
        Console.WriteLine($"|--Adding game--| ");

        Console.WriteLine($"Insert game name: ");
        string gameName = Console.ReadLine();

        Console.WriteLine($"Insert game type: ");
        string gameType = Console.ReadLine().ToLower();

        return Game.Create(gameType, gameName);

        /*
        //currently unused
        Console.WriteLine($"Insert game rate: ");
        string gameRate = Console.ReadLine();
        int.TryParse(gameRate, out int gameRateInt);
        */
    }

    private static void DisplayShortMenu()
    {
        Console.WriteLine($"|---Select Next Action: 1/2/3/+/-/q/s---|");
    }

    public static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    public static void HandleItemAdded(object? sender, Game game)
    {
        Console.WriteLine($"|--Game added--| => {game.Name.ToUpper()} from {sender?.GetType().Name}");
        Console.WriteLine($"-----------------");

    }

    /*
    public void RemoveGame()
    {
        Console.WriteLine($"Insert game name: ");
        string gameName = Console.ReadLine();
    }*/

    /*
    public static void GameAdded(object item)
    {
        var game = (Game)item;
        Console.WriteLine($"{game.Name} added");
    }*/

    /*
    public static void AddGames(IRepository<Game> gameRepository)
    {
        var games = new[]
        {
        new Game { Name = "Tennis" },
        new Game { Name = "Chess" },
        new Game { Name = "Poker" }
        };
        gameRepository.AddBatch(games);
    }*/

}