using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TasterNotes.Persistence.Models.Users;

namespace TasterNotes.Application.Services.Auth
{
    public class JwtService(IConfiguration configuration)
    {
        private readonly int _expiresInMinutes = int.Parse(configuration["Auth:ExpiresInMinutes"]!);
        private readonly SymmetricSecurityKey _securityKey = new(Encoding.UTF8.GetBytes(configuration["Auth:Secret"]!));

        public string GenerateAccessToken(User user)
        {
            var claims = new List<Claim> {
                new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new(ClaimTypes.Name, user.Nickname),
                new(ClaimTypes.Role, user.Role.ToString()),
            };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_expiresInMinutes),
                signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
