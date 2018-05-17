namespace Ackbar.Models.Entities
{
    public class Like
    {
        public long Id { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}