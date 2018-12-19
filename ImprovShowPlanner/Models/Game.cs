using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImprovShowPlanner.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number of Players")]
        public int NumPlayers { get; set; }
        [Display(Name = "Description")]
        public string Desc { get; set; }
        [Display(Name = "Game Type")]
        public int GameTypeId { get; set; }

        public GameType GameType { get; set; }
        public ICollection<Show> ShowDetails { get; set; }
    }
}
