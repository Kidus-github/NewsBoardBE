using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface IContentService
    {
        List<Content> Get();
        Content GetById(string id);
        Content Create(Content entity);
        List<Content> GetListByUsername(string Username);
        void Update(string id, Content entity);
        void Delete(string id);
    }
}
