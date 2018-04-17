using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ackbar.Models;
using Ackbar.Interactors;

namespace Ackbar.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly GameGuideContext _context;
        private readonly ILoginInteractor _login;

        public UserController(GameGuideContext context, ILoginInteractor login)
        {
            _context = context;
            _login = login;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Username = "Alex", Password = "Alvim" });
                _context.SaveChanges();
            }
        }

        [AllowAnonymous]
        [HttpPost("/user/login")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _login.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("/user/signup")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = _login.Signup(request.Username, request.Password);
            if (user == null) return BadRequest();
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class SignupRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}