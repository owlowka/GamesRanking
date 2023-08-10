using GamesRanking.Data.Entities;

namespace GamesRanking.Components.DataProviders.Extensions
{
    public static class EnumerableFilteringExtensions
    {
        public static IEnumerable<Game> ByType(this IEnumerable<Game> query, string type)
        {
            return query.Where(x => x.Type == type);
        }
    }
}
