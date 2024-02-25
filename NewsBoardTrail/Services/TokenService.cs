using Amazon.Runtime;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsBoardBE.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;


        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string GenerateToken(string userId)
        {
            
            var claims = new List<Claim>
        {
            new Claim("sub", userId), 
            new Claim(ClaimTypes.NameIdentifier, userId) 
            
        };

            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: creds
            );

            // Serialize the token to a string
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        public string GetUserIdFromRefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jsonToken = tokenHandler.ReadToken(refreshToken) as JwtSecurityToken;

            if (jsonToken == null)
            {
                // Invalid token
                return null;
            }

            // Accessing claims, including user ID
            var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "sub" || claim.Type == ClaimTypes.NameIdentifier);

            return userIdClaim?.Value;
        }
    }
}
