using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Player
    {
        public long Id { get; set; }
        public ICollection<Like> Likes { get; set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}
