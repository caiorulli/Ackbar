using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using Ackbar.Models;
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
            
            var realUser = _context.Users.First(u => u.Id == userId);
            
            var game = _context.Games.First(g => g.Id.Equals(id));
            var player = realUser.Player;

            var like = new Like
            {
                Game = game,
                Player = player
            };
            realUser.Player.LikedGames.Append(like);
            _context.SaveChanges();
            return Ok();
        }
    }
}
