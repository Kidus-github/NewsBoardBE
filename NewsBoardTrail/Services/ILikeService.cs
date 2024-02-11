using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface ILikeService
    {
        List<likes> Get();
        long GetById(string id);
        likes Create(likes entity);
        
        void Delete(string id);
    }
}
