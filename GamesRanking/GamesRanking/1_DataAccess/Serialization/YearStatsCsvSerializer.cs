using GamesRanking.Data.Entities;
using GamesRanking.DataAccess.CsvReader.Extensions;

namespace GamesRanking.DataAccess.Serialization;
public class YearStatsCsvSerializer : ISerializer<List<YearStats>>
{
    public List<YearStats> Deserialize(string text)
    {
        string[] lines = text.Split(Environment.NewLine)
            .Skip(1)
            .Where(line => line.Length > 0)
            .ToArray();

        List<YearStats>? yearStats = new List<YearStats>();

        foreach (string line in lines)
        {
            string[]? columns = line.Split(';');

            YearStats? oneYearStats = new YearStats()
            {
                Number = columns[0].FieldToInt(),
                TotalAmount = columns[1].FieldToInt(),
                Average = columns[2].FieldToDouble(),
            };
        }

        return yearStats;
    }

    public string Serialize(List<YearStats> list)
    {
        IEnumerable<string>? lines = list.Select(oneYearStats =>
        {
            object[] properties =
                new object[]
                {
                    oneYearStats.Number,
                    oneYearStats.TotalAmount,
                    oneYearStats.Average
                };

            return String.Join(";", properties);
        });

        return String.Join(Environment.NewLine, lines);
    }
}
