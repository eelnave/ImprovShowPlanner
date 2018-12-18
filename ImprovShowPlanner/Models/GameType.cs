using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImprovShowPlanner.Models
{
    public class GameType
    {
        public int GameTypeId { get; set; }
        public string GameForm { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}