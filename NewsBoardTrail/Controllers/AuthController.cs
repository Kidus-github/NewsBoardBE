using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        

        public AuthController(IUserService userService, ITokenService tokenService, IOptions<ITokenService> jwtSettings)
        {
            _userService = userService;
            _tokenService = tokenService;

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.ValidateUserCredentials(model.Email, model.Password);

            if (user == null)
                return Unauthorized();

            var token = _tokenService.GenerateToken(user.UserId);
            return Ok(new { Token = token });
        }

        // Other authentication-related endpoints can go here

        // Example: Refresh token endpoint (optional)
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] RefreshTokenModel refreshToken)
        {
            // Implement logic to retrieve the user ID associated with the refresh token
            var newUserId = _tokenService.GetUserIdFromRefreshToken(refreshToken.RefreshToken);

            if (newUserId == null)
            {
                // Handle invalid or expired refresh token
                return BadRequest("Invalid or expired refresh token");
            }
            var newToken = _tokenService.GenerateToken(newUserId);
            return Ok(new { Token = newToken });
        }
        [HttpGet("userId")]
        public string GetUserIdFromToken(string token)
        {
            return _tokenService.GetUserIdFromRefreshToken(token);
           
        }
    }
}
