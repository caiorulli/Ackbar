using System.Collections.Generic;

namespace Ackbar.Models.Entities
{
    public class Player
    {
        public long Id { get; set; }
        public ICollection<Like> LikedGames { get; set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}
