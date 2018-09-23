using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Ackbar.Api.Dto;
using Ackbar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ackbar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly GameGuideContext _context;
        private readonly IJwtUtils _jwt;

        public UserController(GameGuideContext context, IJwtUtils jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = _jwt.GenerateJwt(user.Id);
            return Ok(new UserDto { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = UserSignup(request.Email, request.Password, request.ReportUrl);
            if (user == null) return BadRequest();
            var tokenString = _jwt.GenerateJwt(user.Id);
            return Ok(new UserDto { Token = tokenString });
        }

        private User UserSignup(string email, string password, string reportUrl)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                return null;
            }
            var user = new User
            {
                Email = email,
                Password = password,
                Player = new Player
                {
                    Likes = new Collection<Like>()
                }
            };
            if (reportUrl != null)
            {
                user.Customer = new Customer
                {
                    ReportUrl = reportUrl,
                    User = user
                };
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        private User Authenticate(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}