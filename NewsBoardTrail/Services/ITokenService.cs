namespace NewsBoardBE.Services
{
    public interface ITokenService
    {
        string GenerateToken(string userId);
        string GetUserIdFromRefreshToken (string refreshToken);
    }
}