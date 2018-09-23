using System;
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
        private readonly IRegressionService _regressionService;

        public PlayerController(GameGuideContext context, IJwtUtils jwt, IRegressionService regressionService)
        {
            _context = context;
            _jwt = jwt;
            _regressionService = regressionService;
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
                Player = player,
                DateTime = DateTime.Now
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
                Player = player,
                DateTime = DateTime.Now
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
                Player = player,
                DateTime = DateTime.Now
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

            try
            {
                var player = _context
                    .Players
                    .Include(p => p.Likes)
                    .ThenInclude(l => l.Game)
                    .ThenInclude(g => g.Profile)
                    .ThenInclude(p => p.Conflict)

                    .Include(p => p.Likes)
                    .ThenInclude(l => l.Game)
                    .ThenInclude(g => g.Profile)
                    .ThenInclude(p => p.Agency)

                    .Include(p => p.Likes)
                    .ThenInclude(l => l.Game)
                    .ThenInclude(g => g.Profile)
                    .ThenInclude(p => p.Appearance)

                    .Include(p => p.Likes)
                    .ThenInclude(l => l.Game)
                    .ThenInclude(g => g.Profile)
                    .ThenInclude(p => p.Investment)

                    .Include(p => p.Likes)
                    .ThenInclude(l => l.Game)
                    .ThenInclude(g => g.Profile)
                    .ThenInclude(p => p.Rules)

                    .First(p => p.User.Id == userId);

                var randomNotLikedGames = _context.Games
                    .FromSql("SELECT TOP (31) * from Games " +
                             " WHERE Id NOT IN (SELECT g.Id FROM Games g " +
                             "INNER JOIN Likes l ON g.Id = l.GameId " +
                             "INNER JOIN Players p ON l.PlayerId = p.Id " +
                             "INNER JOIN Users u ON p.Id = u.PlayerId " +
                             "WHERE u.Id = {0})", userId)
                    .Include(g => g.Profile)
                    .ThenInclude(g => g.Agency)
                    .Include(g => g.Profile)
                    .ThenInclude(g => g.Appearance)
                    .Include(g => g.Profile)
                    .ThenInclude(g => g.Conflict)
                    .Include(g => g.Profile)
                    .ThenInclude(g => g.Investment)
                    .Include(g => g.Profile)
                    .ThenInclude(g => g.Rules)
                    .ToList();

                _regressionService.CalculateRegression(player, randomNotLikedGames);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
