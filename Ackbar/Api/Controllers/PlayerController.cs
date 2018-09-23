using System.Collections.ObjectModel;
using System.Linq;
using Ackbar.Api.Dto;
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
        private readonly IJwtUtils _jwt;

        public PlayerController(GameGuideContext context, IJwtUtils jwt)
        {
            _context = context;
            _jwt = jwt;
        }
        
        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult PlayerSignup([FromBody] PlayerSignupRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest();
            }
            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                Player = new Player
                {
                    Likes = new Collection<Like>(),
                    Views = new Collection<View>(),
                    Ownerships = new Collection<Ownership>(),
                    AvatarUrl = request.AvatarUrl,
                    CollectionSize = request.CollectionSize,
                    WeeklyPlayTime = request.WeeklyPlayTime
                }
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            var tokenString = _jwt.GenerateJwt(user.Id);
            return Ok(new UserDto { Token = tokenString });
        }


        [HttpPost("ViewGame/{id}")]
        public IActionResult ViewGame(long id)
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }
            
            var player = _context.Players.First(p => p.User.Id == userId);
            var game = _context.Games.First(g => g.Id.Equals(id));

            if (_context.Views.Any(l => l.Game.Equals(game) && l.Player.Equals(player)))
            {
                return BadRequest();                
            }
            
            var view = new View
            {
                Game = game,
                Player = player
            };
            _context.Views.Add(view);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpPost("LikeGame/{id}")]
        public IActionResult LikeGame(long id)
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }
            
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

        [HttpPost("OwnGame/{id}")]
        public IActionResult OwnGame(long id)
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }
            
            var player = _context.Players.First(p => p.User.Id == userId);
            var game = _context.Games.First(g => g.Id.Equals(id));

            if (_context.Ownerships.Any(l => l.Game.Equals(game) && l.Player.Equals(player)))
            {
                return BadRequest();                
            }
            
            var ownership = new Ownership
            {
                Game = game,
                Player = player
            };
            _context.Ownerships.Add(ownership);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpGet("Recommendations")]
        public IActionResult Recommendations()
        {
            var userId = _jwt.GetUserIdFromContext(HttpContext.User);
            if (userId == null)
            {
                return Unauthorized();
            }

            var recommendedGames = _context.Games
                .FromSql("SELECT TOP (5) * from Games " +
                         " WHERE Id NOT IN (SELECT g.Id FROM Games g " +
                         "INNER JOIN Likes l ON g.Id = l.GameId " +
                         "INNER JOIN Players p ON l.PlayerId = p.Id " +
                         "INNER JOIN Users u ON p.Id = u.PlayerId " +
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
