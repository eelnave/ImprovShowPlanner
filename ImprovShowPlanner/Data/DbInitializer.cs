using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImprovShowPlanner.Models;

namespace ImprovShowPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(ImprovShowContext context)
        {
            if (context.IndivShows.Any())
            {
                return;
            }

            var indivShows = new IndivShow[]
            {
                new IndivShow{Date = DateTime.Now},
                new IndivShow{Date = DateTime.Parse("Jan 1, 2019 19:00")},
                new IndivShow{Date = DateTime.Parse("Jan 1, 2019 21:00")},

            };
            foreach (IndivShow i in indivShows)
            {
                context.IndivShows.Add(i);
            }
            context.SaveChanges();

            var shows = new Show[]
            {
                new Show{PlayerId=8,GameId=7,IndivShowId=2},
                new Show{PlayerId=9,GameId=7,IndivShowId=1},
                new Show{PlayerId=10,GameId=7,IndivShowId=1},

            };
            foreach (Show s in shows)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();



        }
    }
}
