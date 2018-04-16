using Ackbar.Models;
using System.Linq;

namespace Ackbar.Interactors
{
    public class LikeDislikeGame
    {
        private readonly GameGuideContext _context;

        public LikeDislikeGame(GameGuideContext context)
        {
            _context = context;
        }

        public LikeGameResponse LikeGame(LikeGameRequest request)
        {
            User realUser = _context.Users.First(u => u.Id == request.UserId);
            var game = _context.Games.First(g => g.Id == request.GameId);
            realUser.Player.LikedGames.Append(game);
            return LikeGameResponse.Success;
        }
    }

    public class LikeGameRequest
    {
        public long UserId { get; set; }
        public long GameId { get; set; }
    }

    public enum LikeGameResponse { Success, PlayerNotFound, GameNotFound }
}
