using System.Collections.Generic;
using Ackbar.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
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
    }
}