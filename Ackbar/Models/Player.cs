using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Player
    {
        public long Id { get; set; }
        public ICollection<Game> LikedGames { get; set; }
        public ICollection<Game> DislikedGames { get; set; }
        public User User { get; set; }
    }
}
