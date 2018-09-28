using System.Collections.ObjectModel;

namespace Ackbar.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Player Player { get; set; }
        public Customer Customer { get; set; }

        public static User MakePlayer(string email, string password, string avatarUrl,
            int collectionSize, int weeklyPlayTime)
        {
            return new User
            {
                Email = email,
                Password = password,
                Player = new Player
                {
                    Likes = new Collection<Like>(),
                    Views = new Collection<View>(),
                    Ownerships = new Collection<Ownership>(),
                    AvatarUrl = avatarUrl,
                    CollectionSize = collectionSize,
                    WeeklyPlayTime = weeklyPlayTime
                }
            };
        }
    }
}
