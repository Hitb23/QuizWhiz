using Microsoft.IdentityModel.Tokens;
using server.DataLayer.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(string Email, string Password, string Role)
        {
            var claims = new[]
           {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, Role),
                new Claim(ClaimTypes.Hash, Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
