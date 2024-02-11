using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class CommentService: ICommentService
    {
        private readonly IMongoCollection<Comment> _Comment;

        public CommentService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _Comment = database.GetCollection<Comment>(settings.CommentCollectionName);
        }

        public Comment Create(Comment entity)
        {
            _Comment.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _Comment.DeleteOne(comment => comment.CommentId == id);
        }

        public List<Comment> Get()
        {
            return _Comment.Find(comment => true).ToList();
        }

        public long GetCount(string id)
        {
            return _Comment.CountDocuments(comment => comment.ContentId == id);
        }

        public void Update(string id, Comment entity)
        {
            _Comment.ReplaceOne(comment => comment.CommentId == id, entity);
        }

        public Comment GetById(string id)
        {
            return _Comment.Find(comment => comment.CommentId == id).FirstOrDefault();
        }
    }
}
