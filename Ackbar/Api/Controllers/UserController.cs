using System.Collections.ObjectModel;
using System.Linq;
using Ackbar.Api.Dto;
using Ackbar.Interactors;
using Ackbar.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly ILoginInteractor _login;

        public UserController(GameGuideContext context, ILoginInteractor login)
        {
            var databaseContext = context;
            _login = login;

            if (databaseContext.Users.Any()) return;
            databaseContext.Users.Add(new User
            {
                Email = "Alex",
                Password = "Alvim",
                Player = new Player
                {
                    Likes = new Collection<Like>()
                }
            });
            databaseContext.SaveChanges();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(PlayerDto), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _login.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _login.GenerateJwt(user);
            return Ok(new PlayerDto { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(PlayerDto), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = _login.Signup(request.Email, request.Password);
            if (user == null) return BadRequest();
            var tokenString = _login.GenerateJwt(user);
            return Ok(new PlayerDto { Token = tokenString });
        }
    }
}