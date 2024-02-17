using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface IUser
    {
        User GetById(string id);
        User Create(User entity);
        void Update(string id, User entity);
        void Delete(string id);
        string GetUserName(string id);
    }
}
