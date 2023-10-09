using System.Globalization;
using Bogus;

using CsvHelper;
using CsvHelper.Configuration;

using GamesRanking.Data.Entities;

IList<YearStats> years = new List<YearStats>()
{
    new YearStats
    {
        Id = 1
    }
};

var faker = new Faker<YearStats>();

faker.RuleFor(year => year.Number, f =>
    f.Date
    .BetweenDateOnly(new DateOnly(1990, 1, 1), new DateOnly(2022, 1, 1)).Year);
faker.RuleFor(year => year.TotalAmount, f => f.Random.Number(50));
faker.RuleFor(year => year.Average, f => Math.Round(f.Random.Double(10.00), 2));


//foreach(var game in games)
//{
//    faker.Populate(game);
//}

years = faker.GenerateForever().Take(50).ToList();

var configuration = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };

using (var fileWriter = new StreamWriter(File.OpenWrite("game_data.csv")))
{
    using var writer = new CsvWriter(fileWriter, configuration);

    await writer.WriteRecordsAsync(years);
}
