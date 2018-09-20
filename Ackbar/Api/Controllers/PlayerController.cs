using System.Linq;
using System.Security.Claims;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ackbar.Api.Controllers
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

        [HttpGet("Recommendations")]
        public IActionResult Recommendations()
        {
            var currentUser = HttpContext.User;
            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }
            var userId = long.Parse(currentUser.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var recommendedGames = _context.Games
                .FromSql("SELECT TOP (5) * from Games " +
                         " WHERE Id NOT IN (SELECT g.Id FROM Games g " +
                         "INNER JOIN Likes l ON g.Id = l.GameId " +
                         "INNER JOIN Players p ON l.PlayerId = p.Id " +
                         "INNER JOIN Users u ON u.Id = p.UserId " +
                         "WHERE u.Id = {0})", userId)
                .ToArray();

            var recommendations = new long[recommendedGames.Length];
            for (var i = 0; i < recommendedGames.Length; i++)
            {
                recommendations[i] = recommendedGames[i].Id;
            }

            return Ok(recommendations);
        }
    }
}
