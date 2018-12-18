using System;
using System.Collections.Generic;
namespace ImprovShowPlanner.Models
{
    public class IndivShow
    {
        public int IndivShowId { get; set;}
        public DateTime Date { get; set; }

        public ICollection<Show> ShowDetails { get; set; }
    }
}
