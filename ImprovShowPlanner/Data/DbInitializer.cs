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
            if (context.GameTypes.Any())
            {
                return;
            }
            var players = new Player[]
            {
                new Player{FirstName="Evan", LastName="Peterson",NewPlayer=false},
                new Player{FirstName="Nate", LastName="Wadsworth",NewPlayer=true}
            };
            foreach (Player p in players)
            {
                context.Players.Add(p);
            }
            context.SaveChanges();

            var gameTypes = new GameType[]
            {
                new GameType{GameForm = "Long Form"},
                new GameType{GameForm = "Short Form"},
            };
            foreach (GameType gt in gameTypes)
            {
                context.GameTypes.Add(gt);
            }
            context.SaveChanges();

            var games = new Game[]
            {
                new Game{Name="SomeGame",NumPlayers=2,Desc="do some stuff",GameTypeId = 1},
                new Game{Name="AnotherGame",NumPlayers=1,Desc="do some other stuff",GameTypeId=2}
            };
            foreach (Game g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();

            var indivShows = new IndivShow[]
            {
                new IndivShow{Date = DateTime.Now},
                new IndivShow{Date = DateTime.Now},
                new IndivShow{Date = DateTime.Now},

            };
            foreach (IndivShow i in indivShows)
            {
                context.IndivShows.Add(i);
            }
            context.SaveChanges();

            var shows = new Show[]
            {
                new Show{PlayerId=1,GameId=3,IndivShowId=2},
                new Show{PlayerId=2,GameId=1,IndivShowId=1},
                new Show{PlayerId=1,GameId=2,IndivShowId=1},

            };
            foreach (Show s in shows)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();



        }
    }
}
