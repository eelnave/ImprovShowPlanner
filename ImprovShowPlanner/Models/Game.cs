using System.Collections.Generic;

namespace ImprovShowPlanner.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int NumPlayers { get; set; }
        public string Desc { get; set; }
        public int GameTypeId { get; set; }

        public GameType GameType { get; set; }
        public ICollection<Show> ShowDetails { get; set; }
    }
}
