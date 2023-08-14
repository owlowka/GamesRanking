using GamesRanking.Components.CsvReader.Models;
using GamesRanking.Components.CsvReader;
using System.Xml.Linq;

namespace GamesRanking.App;
public class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(
        ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        CreateXml();
        QueryXml();
    }

    private static void QueryXml()
    {
        var document = XDocument.Load("bgg_dataset.xml");
        var names = document
            .Element("Games")?
            .Elements("Game")
            .Where(x => x.Attribute("YearPublished")?.Value == "2020")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private void CreateXml()
    {
        List<Game> games = _csvReader.ProcessGames("C:\\repos\\GamesRanking\\GamesRanking\\GamesRanking\\Resources\\Files\\bgg_dataset.csv");

        var document = new XDocument();
        var xmlGames = new XElement("Games", games
            .Select(game =>
                new XElement("Game",
                    CreateAttribute("Id", game.Id),
                    CreateAttribute("Name", game.Name),
                    CreateAttribute("YearPublished", game.YearPublished),
                    CreateAttribute("MinPlayers", game.MinPlayers),
                    CreateAttribute("MaxPlayers", game.MaxPlayers),
                    CreateAttribute("PlayTime", game.PlayTime),
                    CreateAttribute("MinAge", game.MinAge),
                    CreateAttribute("UsersRated", game.UsersRated),
                    CreateAttribute("RatingAverage", game.RatingAverage),
                    CreateAttribute("BggRank", game.BggRank),
                    CreateAttribute("ComplexityAverage", game.ComplexityAverage),
                    CreateAttribute("OwnedUsers", game.OwnedUsers),
                    CreateAttribute("Mechanics", game.Mechanics),
                    CreateAttribute("Domains", game.Domains)
                )));

        document.Add(xmlGames);
        document.Save("bgg_dataset.xml");
    }

    public static XAttribute CreateAttribute(string attributeName, object value)
    {
        return new XAttribute(attributeName, value ?? String.Empty);
    }
}
