using System.Text.Json.Serialization;

namespace GamesRanking.Entities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
    [JsonDerivedType(typeof(Analog), nameof(Analog))]
    [JsonDerivedType(typeof(Virtual), nameof(Virtual))]
    public class Game : EntityBase
    {
        public string? Name { get; set; }

        public static Game Create(string type, string name)
        {
            Game game = type switch
            {
                "virtual" => new Virtual(),
                "analog" => new Analog(),
                _ => new Game()
            };

            game.Name = name;

            return game;
        }
        public override string ToString() => $"{Id}, {char.ToUpper(Name[0])}{Name[1..]}";

    }
}
