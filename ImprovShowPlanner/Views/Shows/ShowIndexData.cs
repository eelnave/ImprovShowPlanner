using System;
using System.Collections.Generic;
using ImprovShowPlanner.Models;

namespace ImprovShowPlanner.Views.Shows
{
    public class ShowIndexData
    {
        public IEnumerable<Show> Shows { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Models.Player> Players { get; set; }
    }
}
