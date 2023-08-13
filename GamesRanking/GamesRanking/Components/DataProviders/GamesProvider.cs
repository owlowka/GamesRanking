using GamesRanking.Components.DataProviders.Extensions;
using GamesRanking.Data.Entities;
using GamesRanking.Data.Repositories;

using static GamesRanking.UserCommunication.PrintingExtensions;

namespace GamesRanking.Components.DataProviders
{
    public class GamesProvider : IGamesProvider
    {
        private readonly IRepository<Game> _gamesRepository;
        public GamesProvider(IRepository<Game> gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public List<Game> GetAllGames() =>
            _gamesRepository
                .GetAll()
                .ToList();

        public List<Game> GetAllGamesOfType(string type) =>
            _gamesRepository
                .GetAll()
                .Where(game => game.Type == type)
                .ToList();

        public List<Game> GetThreeTheBestGames() =>
            _gamesRepository
                .GetAll()
                .OrderBy(x => x.AvgScore)
                .Take(3)
                .ToList();

        public void AddGame(Game game)
        {
            _gamesRepository.Add(game);
        }

        public void RemoveByName(string name)
        {
            var gamesToRemove = _gamesRepository
                .GetAll()
                .Where(x => x.Name == name);

            foreach (var gameToRemove in gamesToRemove)
            {
                _gamesRepository.Remove(gameToRemove);
            }
        }
        public void Save()
        {

        }

        public List<Game[]> ChunkGames(int size)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .Chunk(size)
                .ToList();

        }

        public List<string> DistinctAllTypes()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .Select(x =>
                {
                    return x.Type ?? "no type";
                })
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public List<Game> DistinctByTypes()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .DistinctBy(x => x.Type)
                .OrderBy(x => x.Type)
                .ToList();
        }



        public List<Game> FilterGamesByAge(int minAge)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .Where(x => x.PlayerAge >= minAge)
                .ToList();

        }

        public Game FirstByType(string type)
        {
            PrintMethodName();

            Console.WriteLine($"First By Type");

            var games = _gamesRepository.GetAll();

            return games
                .First(game => game.Type == type);

        }

        public Game? FirstOrDefaultByType(string type)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .FirstOrDefault(x => x.Type == type);
        }

        public Game FirstOrDefaultByTypeWithDefault(string type)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .FirstOrDefault(
                    x => x.Type == type,
                    new Game { Id = -1, Name = "not found" });
        }

        public double? GetMaxAverageScoreOfAllGames()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .Select(x => x.AvgScore).Min();
        }

        public List<Game> GetSpecificColumns()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            var list = games
                .Select(game => new Game
                {
                    Id = game.Id,
                    Name = game.Name,
                    Type = game.Type
                })
                .ToList();

            return list;
        }

        public List<string> GetUniqueGameKind()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            var kind = games
                .Select(x => x.Kind ?? "no kind")
                .Distinct()
                .ToList();

            return kind;
        }

        public Game LastByType(string type)
        {
            PrintMethodName();

            var game = _gamesRepository.GetAll();

            return game
                .Last(x => x.Type == type);
        }

        //order by
        public List<Game> OrderByName()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .OrderBy(x => x.Name)
                .ToList();
        }

        public List<Game> OrderByNameDescending()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games.OrderByDescending(x => x.Name).ToList();

        }

        public List<Game> OrderByTypeAndName()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .OrderBy(x => x.Type)
                .ThenBy(x => x.Name)
                .ToList();

        }

        public List<Game> OrderByTypeAndNameDescending()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .OrderByDescending(x => x.Type)
                .ThenByDescending(x => x.Name)
                .ToList();
        }

        public Game SingleById(int id)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games.Single(x => x.Id == id);
        }

        public Game SingleOrDefaultById(int id)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .SingleOrDefault(x => x.Id == id,
                 new Game());

        }

        public List<Game> SkipGames(int howMany)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();

            return games
                .OrderBy(x => x.Name)
                .Skip(howMany)
                .ToList();
        }

        public List<Game> SkipGamesWhileNameNotStartsWith(string prefix)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .OrderBy(x => x.Name)
                .SkipWhile(x =>
                {
                    bool startsWith = x.Name.StartsWith(prefix);
                    return !startsWith;
                })
            .ToList();
        }
        public List<Game> TakeGames(int howMany)
        {
            PrintMethodName();
            var games = _gamesRepository.GetAll();
            return games
            .OrderBy(x => x.Name)
            .Take(howMany)
            .ToList();
        }
        public List<Game> TakeGames(Range range)
        {
            PrintMethodName();
            var games = _gamesRepository.GetAll();
            return games
            .OrderBy(x => x.Name)
            .Take(4..10)
            .ToList();
        }

        public List<Game> TakeGamesWhileNameStartsWith(string prefix)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .OrderBy(x => x.Name)
                .TakeWhile(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Game> WhereStartsWith(string prefix)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .Where(x => x.Name.StartsWith(prefix))
                .ToList();
        }

        public List<Game> WhereStartsWithAndAvgScoreIsGreaterThan(string prefix, double avgScore)
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .Where(x => x.Name.StartsWith(prefix) && x.AvgScore > avgScore)
                .ToList();
        }

        public List<Game> WhereTypeIs()
        {
            PrintMethodName();

            var games = _gamesRepository.GetAll();
            return games
                .ByType("virtual")
                .ToList();
        }

    }
}
