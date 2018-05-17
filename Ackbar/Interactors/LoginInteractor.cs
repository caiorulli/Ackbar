using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Ackbar.Models.Entities;

namespace Ackbar.Interactors
{
    public class LoginInteractor : ILoginInteractor
    {
        private readonly GameGuideContext _context;
        private readonly IConfiguration _config;

        public LoginInteractor(GameGuideContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public User Signup(string email, string password)
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
