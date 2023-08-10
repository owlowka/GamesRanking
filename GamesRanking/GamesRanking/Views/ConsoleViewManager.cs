using GamesRanking.Components.DataProviders;
using GamesRanking.Data.Entities;


namespace GamesRanking.UserCommunication;
public class ConsoleViewManager : IViewManager
{
    private readonly IGamesProvider _gamesProvider;

    public ConsoleViewManager(
        IGamesProvider gamesProvider)
    {
        _gamesProvider = gamesProvider;
    }

    public void DisplayMenu()
    {
        string userInput;

        Console.WriteLine($"|---------------------------GAMES RANKING--------------------------|");
        Console.WriteLine();
        Console.WriteLine($"(1) Display all games ranking ");
        Console.WriteLine($"(a) Display three the best games in ranking ");
        Console.WriteLine($"(2) Display analog games ranking ");
        Console.WriteLine($"(3) Display virtual games ranking ");
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
            SelectAction(result, _gamesProvider);
        }
        while (userInput != "q");
    }

    public void SelectAction(char menuCharacter, IGamesProvider gamesProvider)
    {
        switch (menuCharacter)
        {
            case '1':
                Console.WriteLine($" All games ranking ");
                WriteAllToConsole(gamesProvider);
                DisplayShortMenu();
                break;
            case 'a':
                Console.WriteLine($" Three The best games in ranking ");
                WriteThreeTheBestGamesToConsole(gamesProvider);
                DisplayShortMenu();
                break;
            case '2':
                Console.WriteLine($" Analog games ranking ");
                WriteAllAnalogTypeToConsole(gamesProvider);
                DisplayShortMenu();
                break;
            case '3':
                Console.WriteLine($" Virtual games ranking ");
                WriteAllVirtualTypeToConsole(gamesProvider);
                DisplayShortMenu();
                break;
            case '+':
                Game gameToAdd = GetGameDetails();
                gamesProvider.AddGame(gameToAdd);
                DisplayShortMenu();
                break;
            case '-':
                Console.WriteLine($"|--Removing game--| ");
                string gameToRemove = GetGameName();
                _gamesProvider.RemoveByName(gameToRemove);
                DisplayShortMenu();
                break;
            case 's':
                Console.WriteLine($" Changes saved ");
                gamesProvider.Save();
                DisplayShortMenu();
                break;
            case 'q':
                Console.Clear();
                Console.WriteLine($"Quit");
                Console.WriteLine($"|-------------------------THANK'S FOR VOTING-----------------------|");
                break;
        }
    }

    private static void DisplayShortMenu()
    {
        Console.WriteLine($"|---Select Next Action: 1/2/3/+/-/q/s---|");
    }

    public static Game GetGameDetails()
    {
        Console.WriteLine($"|--Adding game--| ");

        Console.WriteLine($"Insert game name: ");
        string? gameName = Console.ReadLine();

        Console.WriteLine($"Insert game type: ");
        string? gameType = Console.ReadLine()?.ToLower();

        return new Game
        {
            Type = gameType,
            Name = gameName
        };
    }

    private static int GetGameRate()
    {
        Console.WriteLine($"Insert game rate: ");
        string gameRate = Console.ReadLine();
        int.TryParse(gameRate, out int gameRateInt);

        return gameRateInt;
    }

    public static string GetGameName()
    {
        Console.WriteLine($"Insert game name: ");
        string gameName = Console.ReadLine();
        return gameName;

    }

    public static void WriteAllToConsole(IGamesProvider gamesProvider)
    {
        var items = gamesProvider.GetAllGames();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public static void WriteAllVirtualTypeToConsole(IGamesProvider provider)
    {
        var items = provider.GetAllGamesOfType("virtual");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public static void WriteAllAnalogTypeToConsole(IGamesProvider provider)
    {
        var items = provider.GetAllGamesOfType("analog");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private static void WriteThreeTheBestGamesToConsole(IGamesProvider gamesProvider)
    {
        List<Game> items = gamesProvider.GetThreeTheBestGames();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
