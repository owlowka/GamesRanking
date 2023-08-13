namespace GamesRanking.Data.Entities
{
    //[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
    //[JsonDerivedType(typeof(Analog), nameof(Analog))]
    //[JsonDerivedType(typeof(Virtual), nameof(Virtual))]
    public class Game : EntityBase
    {
        public string Name { get; set; } = "no name";

        public int? PlayersCount { get; set; }

        public int? PlayerAge { get; set; }

        public string Type { get; set; }

        public string Kind { get; set; }

        public double? AvgScore { get; set; }


        // Calculated Properties
        public double? TotalScore { get; set; }

        public static Game Create(string type, string name)
        {
            Game game = type switch
            {
                "virtual" => new Game(),
                "analog" => new Game(),
                _ => new Game()
            };

            game.Name = name;

            return game;
        }
        public override string ToString()
        {
            var name = $"{char.ToUpper(Name[0])}{Name[1..]}";

            string text =
                $"""

                {name} (name) | {Type ?? "no type"} (type)"
                {Id} (id)
                {AvgScore} (avgScore)
                {PlayersCount} (players)
                {PlayerAge} (age)

                """;

            return text;
        }
    }
}
