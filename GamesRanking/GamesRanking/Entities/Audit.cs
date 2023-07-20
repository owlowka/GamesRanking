using System.Text.Json.Serialization;

namespace GamesRanking.Entities
{
    public class Audit : EntityBase
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string Comment { get; set; }

    }
}
