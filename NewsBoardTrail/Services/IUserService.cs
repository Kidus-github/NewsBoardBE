using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface IUserService
    {
        User ValidateUserCredentials(string email, string password);
    }
}
