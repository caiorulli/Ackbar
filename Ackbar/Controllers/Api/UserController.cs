using System.Linq;
using Ackbar.Interactors;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ackbar.Controllers.Api
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
            databaseContext.Users.Add(new User { Email = "Alex", Password = "Alvim" });
            databaseContext.SaveChanges();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _login.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = _login.Signup(request.Email, request.Password);
            if (user == null) return BadRequest();
            var tokenString = _login.GenerateJwt(user);
            return Ok(new TokenResponse { Token = tokenString });
        }
    }

    public class LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }

    public class SignupRequest
    {
        public SignupRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
    }
}