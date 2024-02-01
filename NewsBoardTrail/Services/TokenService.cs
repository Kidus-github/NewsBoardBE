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
        /* public string GenerateToken(string userId)
         {
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new Claim[]
                 {
                     new Claim(ClaimTypes.Name, userId) }),
                 Expires = DateTime.UtcNow.AddHours(1),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token =tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);
         }*/
        public string GenerateToken(string userId)
        {
            
            var claims = new List<Claim>
        {
            new Claim("sub", userId), 
            new Claim(ClaimTypes.NameIdentifier, userId) 
            
        };

            
            var secretKey = _configuration["JwtSettings:SecretKey"];

            var key = Encoding.UTF8.GetBytes(secretKey);

            
            var creds = new SigningCredentials((new SymmetricSecurityKey(key)), SecurityAlgorithms.HmacSha256);

            
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
