using GamesRanking.Repositories;
using GamesRanking.Entities;
using GamesRanking.Data;
using System.ComponentModel;
using GamesRanking;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"|---------------------------GAMES RANKING--------------------------|");
        Console.WriteLine();
        Console.WriteLine($"(1) Display all games ranking ");
        Console.WriteLine($"(2) Display analog games ranking ");
        Console.WriteLine($"(3) Display virtual games ranking ");
        Console.WriteLine($"(+) Add game ");
        Console.WriteLine($"(-) Remove game ");
        Console.WriteLine($"(s) Save ");
        Console.WriteLine($"(q) Quit ");
        Console.WriteLine();
        Console.WriteLine($"|---Select action. To confirm press Enter.---|");
        Console.WriteLine();

        Scenarios();

        static void Scenarios()
        {
            string fileName = "GameRanking.json";
            string auditFile = "AuditFile.json";

            IRepository<Audit> auditRepository = new FileRepository<Audit>(auditFile);

            IRepository<Game> gameRepository = new FileRepository<Game>(fileName);

            RepositoryAuditSubscriber<Game> repositorySubscriber =
                new RepositoryAuditSubscriber<Game>(auditRepository, gameRepository);

            repositorySubscriber.Subscribe();

            gameRepository.ItemAdded += Logic.HandleItemAdded;
            string userInput;



            do
            {
                userInput = Console.ReadLine();
                char.TryParse(userInput, out char result);
                Logic.SelectAction(result, gameRepository);
            }
            while (userInput != "q");
        }
    }
}