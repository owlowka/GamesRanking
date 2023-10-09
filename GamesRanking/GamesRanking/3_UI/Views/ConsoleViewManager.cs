using GamesRanking.DataAccess.CsvReader.Extensions;
using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.Repositories;


namespace GamesRanking.UI.Views;
public class ConsoleViewManager : IViewManager
{
    private readonly IRepository<Game> _repository;


    public ConsoleViewManager(IRepository<Game> repository)
    {
        _repository = repository;
    }

    public void DisplayMenu()
    {
        string userInput;

        Console.WriteLine($"|---------------------------GAMES RANKING--------------------------|");
        Console.WriteLine();
        Console.WriteLine($"(1) Display all games ranking ");
        Console.WriteLine($"(2) Display easy games ");
        Console.WriteLine($"(3) Display hard games ");
        Console.WriteLine($"(4) Display three the best games in ranking ");
        Console.WriteLine($"(+) Add game ");
        Console.WriteLine($"(-) Remove game ");
        Console.WriteLine($"(s) Save ");
        Console.WriteLine($"(q) Quit ");
        Console.WriteLine();
        Console.WriteLine($"|---------------Select action. To confirm press Enter.--------------|");
        Console.WriteLine();

        do
        {
            userInput = Console.ReadLine();
            char.TryParse(userInput, out char result);
            SelectAction(result);
        }
        while (userInput != "q");
    }

    public void SelectAction(char menuCharacter)
    {
        switch (menuCharacter)
        {
            case '1':
                WriteAllToConsole();
                break;
            case '2':
                WriteEasyGamesToConsole();
                break;
            case '3':
                WriteHardGamesToConsole();
                break;
            case '4':
                WriteThreeTheBestGamesToConsole();
                break;
            case '+':
                AddGame();
                break;
            case '-':
                RemoveGame();
                break;
            case 's':
                SaveChanges();
                break;
            case 'q':
                Quit();
                return;
        }

        DisplayShortMenu();
    }

    private static void Quit()
    {
        Console.Clear();
        Console.WriteLine($"Quit");
        Console.WriteLine($"|-------------------------THANK'S FOR VOTING-----------------------|");
    }

    private void SaveChanges()
    {
        Console.WriteLine($" Changes saved ");
        _repository.Save();
    }

    private void RemoveGame()
    {
        Console.WriteLine($"|--Removing game--| ");
        Game gameToRemove = GetGameById();
        _repository.Remove(gameToRemove);
    }

    private void AddGame()
    {
        Game gameToAdd = GetGameDetails();
        _repository.Add(gameToAdd);
    }

    private static void DisplayShortMenu()
    {
        Console.WriteLine($"|---Select Next Action: 1/2/3/4/+/-/q/s---|");
    }

    public static Game GetGameDetails()
    {
        Console.WriteLine($"|--Adding game--| ");

        Console.WriteLine($"Insert game name: ");
        string? name = Console.ReadLine();

        Console.WriteLine($"Insert year of publishing: ");
        string? year = Console.ReadLine()?.ToLower();

        Console.WriteLine($"Insert min number of players: ");
        string? minPlayers = Console.ReadLine();

        Console.WriteLine($"Insert max number of players: ");
        string? maxPlayers = Console.ReadLine();

        Console.WriteLine($"Insert playtime in minutes: ");
        string? playTime = Console.ReadLine();

        Console.WriteLine($"Insert your rate 1-10: ");
        string? usersRate = Console.ReadLine();

        Console.WriteLine($"Rate complexity 1-5: ");
        string? usersComplexityRate = Console.ReadLine();

        return new Game
        {
            Name = name,
            YearPublished = year.FieldToInt(),
            MinPlayers = minPlayers.FieldToInt(),
            MaxPlayers = maxPlayers.FieldToInt(),
            PlayTime = playTime.FieldToInt(),
            UsersRated = usersRate.FieldToDouble(),
            RatingAverage = usersComplexityRate.FieldToDouble(),
        };
    }

    public Game GetGameById()
    {
        Console.WriteLine($"Insert game Id: ");
        int? gameId = Console.ReadLine().FieldToInt();
        var gameRecord = _repository.GetById(gameId.Value);
        return gameRecord;

    }

    public void WriteAllToConsole()
    {
        Console.WriteLine($" All games ranking ");

        var items = _repository.GetAll();
        foreach (Game item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void WriteEasyGamesToConsole()
    {
        Console.WriteLine($" Display easy games ");

        var items = _repository.GetAll().Where(game => game.ComplexityAverage < 2);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void WriteHardGamesToConsole()
    {
        Console.WriteLine($" Display hard games ");

        IEnumerable<Game>? items = _repository.GetAll().Where(game => game.ComplexityAverage > 4);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private void WriteThreeTheBestGamesToConsole()
    {
        Console.WriteLine($" Three the best games in ranking ");

        IEnumerable<Game>? items = _repository.GetAll()
            .OrderBy(game => game.RatingAverage)
            .Take(3)
            .ToList();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
