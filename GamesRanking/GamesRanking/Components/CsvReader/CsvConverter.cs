//using GamesRanking.Data.Entities;

//namespace GamesRanking
//{
//    public class CsvConverter : ISerializer<Game>
//    {
//        public string Serialize(Game game)
//        {
//            string type = game switch
//            {
//                Analog => "analog",
//                Virtual => "virtual"
//            };

//            string name = game.Name;
//            int? id = game.Id;

//            return $"{id},{type}, {name}";
//        }

//        public Game Deserialize(string text)
//        {
//            string[] words = text.Split(',');

//            string number = words[0].Trim();
//            int.TryParse(number, out int id);
//            string type = words[1].Trim();
//            string name = words[2].Trim();
//            Game game = Game.Create(type, name);
//            game.Id = id;
//            return game;
//        }
//    }
//}
