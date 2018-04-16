using Ackbar.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Ackbar.Interactors
{
    public class Login
    {
        private readonly GameGuideContext _context;
        private readonly IConfiguration _config;

        public Login(GameGuideContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public User Signup(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                return null;
            }
            var user = new User { Username = username, Password = password, Player = new Player() };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Authenticate(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
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
