namespace ImprovShowPlanner.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int IndivShowId { get; set; }

        public Player Player { get; set; }
        public Game Game { get; set; }
        public IndivShow IndivShow { get; set; }

    }
}