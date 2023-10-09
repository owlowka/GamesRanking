using System.Text.Json.Serialization;

namespace GamesRanking.Data.Entities;

public record Audit : EntityBase
{
    public DateTime Timestamp { get; set; }
    public string Action { get; set; }
    public string Comment { get; set; }

}
