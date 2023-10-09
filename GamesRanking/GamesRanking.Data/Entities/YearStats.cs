namespace GamesRanking.Data.Entities;
public record YearStats : EntityBase
{
    public int? Number { get; set; }

    public int? TotalAmount { get; set; }

    public double? Average { get; set; }
}