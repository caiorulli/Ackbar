using System.Linq;
using System.Security.Claims;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly GameGuideContext _context;

        public PlayerController(GameGuideContext context)
        {
            _context = context;
        }
        
        public IActionResult LikeGame(long Id)
        {
            var currentUser = HttpContext.User;
            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            var userId = long.Parse(currentUser.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            
            User realUser = _context.Users.First(u => u.Id == userId);
            var game = _context.Games.First(g => g.Id == Id);
            realUser.Player.LikedGames.Append(game);
            return Ok();
        }
    }
}
