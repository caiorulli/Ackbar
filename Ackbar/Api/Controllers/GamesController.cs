using System.Collections.Generic;
using Ackbar.Api.Dto;
using Ackbar.Models;
using Ackbar.Models.ProfileTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ackbar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    [AllowAnonymous]
    public class GamesController : Controller
    {
        private readonly GameGuideContext _context;

        public GamesController(GameGuideContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return _context.Games;
        }

        [HttpPut("load")]
        public IActionResult LoadGames([FromBody] GameListDataDto listDto)
        {
            var games = _context.Games
                .Include(g => g.Likes)
                .Include(g => g.Views)
                .Include(g => g.Ownerships)
                .Include(g => g.Profile)
                .ThenInclude(g => g.Agency)
                .Include(g => g.Profile)
                .ThenInclude(g => g.Appearance)
                .Include(g => g.Profile)
                .ThenInclude(g => g.Conflict)
                .Include(g => g.Profile)
                .ThenInclude(g => g.Investment)
                .Include(g => g.Profile)
                .ThenInclude(g => g.Rules);
            
            foreach (var game in games)
            {
                foreach (var like in game.Likes)
                {
                    _context.Remove(like);
                }

                foreach (var ownership in game.Ownerships)
                {
                    _context.Remove(ownership);
                }

                foreach (var view in game.Views)
                {
                    _context.Remove(view);
                }

                if (game.Profile != null)
                {
                    var profile = game.Profile;
                    _context.Remove(profile.Agency);
                    _context.Remove(profile.Appearance);
                    _context.Remove(profile.Conflict);
                    _context.Remove(profile.Investment);
                    _context.Remove(profile.Rules);
                    _context.Remove(profile);
                }
                _context.Remove(game);
            }
            
            foreach (var gameDto in listDto.Games)
            {
                var newAgency = new Agency
                {
                    Gradation = gameDto.Gradation,
                    Participation = gameDto.Participation,
                    Result = gameDto.Result
                };
                var newAppearance = new Appearance
                {
                    Quality = gameDto.Quality,
                    Theme = gameDto.Theme,
                    Transmediality = gameDto.Transmediality,
                    VisualIdentity = gameDto.VisualIdentity
                };
                var newConflict = new Conflict
                {
                    Competitivity = gameDto.Competitivity,
                    Economy = gameDto.Economy,
                    Feedback = gameDto.Feedback,
                    Interaction = gameDto.Interaction,
                    Structure = gameDto.Structure,
                    Symmetry = gameDto.Symmetry,
                    CognitiveAbility = gameDto.CognitiveAbility,
                    MentalAbility = gameDto.MentalAbility,
                    PhysicalAbility = gameDto.PhysicalAbility,
                    SocialAbility = gameDto.SocialAbility
                };
                var newInvestment = new Investment
                {
                    Duration = gameDto.DurationValue,
                    Monetary = gameDto.Investment,
                    Setup = gameDto.Preparation,
                    Space = gameDto.Space
                };
                var newRules = new Rules
                {
                    Actions = gameDto.Actions,
                    Components = gameDto.Components,
                    Conditions = gameDto.Conditions,
                    Randomness = gameDto.Randomness,
                    Resources = gameDto.Resources,
                    Variance = gameDto.Variance,
                    VictoryConditions = gameDto.VictoryConditions,
                    IdealNumberOfPlayers = gameDto.IdealNumberOfPlayers,
                    RealNumberOfPlayers = gameDto.RealNumberOfPlayers
                };
                var newProfile = new Profile
                {
                    Appearance = newAppearance,
                    Conflict = newConflict,
                    Investment = newInvestment,
                    Rules = newRules,
                    Agency = newAgency
                };
                var newGame = new Game
                {
                    Name = gameDto.Name,
                    Year = gameDto.YearInBrazil,
                    Age = gameDto.RecommendedAge,
                    Description = gameDto.Description,
                    Duration = gameDto.Duration,
                    CoverImage = gameDto.ImageUrl,
                    NumberOfPlayers = gameDto.NumberOfPlayers,
                    Genre = gameDto.Genre,
                    Publisher = gameDto.Publisher,
                    SellingPrice = gameDto.SellingPrice,
                    Profile = newProfile
                };
                _context.Games.Add(newGame);
            }

            _context.SaveChanges();

            return Ok(_context.Games);
        }
    }
}