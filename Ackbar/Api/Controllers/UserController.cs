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
        private readonly IConfiguration _config;

        public UserController(GameGuideContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            

            if (_context.Users.Any()) return;
            _context.Users.Add(new User
            {
                Email = "Alex",
                Password = "Alvim",
                Player = new Player
                {
                    Likes = new Collection<Like>()
                }
            });
            _context.SaveChanges();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(typeof(PlayerDto), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = GenerateJwt(user);
            return Ok(new PlayerDto { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("Signup")]
        [ProducesResponseType(typeof(PlayerDto), 200)]
        public IActionResult Signup([FromBody] SignupRequest request)
        {
            var user = UserSignup(request.Email, request.Password);
            if (user == null) return BadRequest();
            var tokenString = GenerateJwt(user);
            return Ok(new PlayerDto { Token = tokenString });
        }
        
        public User UserSignup(string email, string password)
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
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Authenticate(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public string GenerateJwt(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}