using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Player
    {
        public long Id { get; set; }
        public int WeeklyPlayTime { get; set; }
        public int CollectionSize { get; set; }
        public string AvatarUrl { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<View> Views { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }
        public User User { get; set; }
        
        public float RegressionAlpha { get; set; }
        public RegressionProfile Profile { get; set; }
    }
}
