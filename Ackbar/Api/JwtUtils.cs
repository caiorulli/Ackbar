using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ackbar.Api
{
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _config;
        
        public JwtUtils(IConfiguration config)
        {
            _config = config;
        }
        
        public string GenerateJwt(long id)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, id.ToString())
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
        
        public long? GetUserIdFromContext(ClaimsPrincipal currentUser)
        {
            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return null;
            }
            return long.Parse(currentUser.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}