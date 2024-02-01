using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBoardBE.Modals;
using NewsBoardBE.Services;

namespace NewsBoardBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;

        }

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
    }
}
