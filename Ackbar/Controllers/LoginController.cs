using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Ackbar.Models;
using Microsoft.Extensions.Configuration;

namespace Ackbar.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly UserContext _context;
        private readonly IConfiguration _config;

        public LoginController(UserContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Username = "Alex", Password = "Alvim" });
                _context.SaveChanges();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var tokenString = BuildToken(user);
            return Ok(new LoginResponse { Token = tokenString });
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }


}