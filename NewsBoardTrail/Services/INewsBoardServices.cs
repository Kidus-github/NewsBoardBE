using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface INewsBoardServices<T>
    {
        List<T> Get();
        T GetById(string id);
        T Create(T entity);
        void Update(string id, T entity);
        void Delete(string id);
    }
}
