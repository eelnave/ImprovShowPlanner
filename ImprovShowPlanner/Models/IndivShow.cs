using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImprovShowPlanner.Models
{
    public class IndivShow
    {
        public int IndivShowId { get; set;}
        [DataType(DataType.DateTime)]
        [Display(Name = "Show Date")]
        public DateTime Date { get; set; }

        public ICollection<Show> ShowDetails { get; set; }
    }
}
