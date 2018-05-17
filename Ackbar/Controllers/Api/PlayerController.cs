using System.Linq;
using System.Security.Claims;
using Ackbar.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Player")]
    public class PlayerController : Controller
    {
        private readonly GameGuideContext _context;

        public PlayerController(GameGuideContext context)
        {
            _context = context;
        }
        
        [HttpPost("LikeGame/{id}")]
        public IActionResult LikeGame(long id)
        {
            var currentUser = HttpContext.User;
            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            var userId = long.Parse(currentUser.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            
            var player = _context.Players.First(p => p.User.Id == userId);
            var game = _context.Games.First(g => g.Id.Equals(id));

            if (_context.Likes.Any(l => l.Game.Equals(game) && l.Player.Equals(player)))
            {
                return BadRequest();                
            }
            
            var like = new Like
            {
                Game = game,
                Player = player
            };
            _context.Likes.Add(like);
            _context.SaveChanges();
            return Ok();
        }
    }
}
