using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public interface ICommentService
    {
        List<Comment> Get();
        Comment GetById(string id);
        List<Comment> GetListById(string id);
        long GetCount(string id);

        Comment Create(Comment entity);
        void Update(string id, Comment entity);
        void Delete(string id);
    }
}
