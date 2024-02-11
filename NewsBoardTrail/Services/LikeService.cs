using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class LikeService : ILikeService
    {
        private readonly IMongoCollection<likes> _like;

        public LikeService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _like = database.GetCollection<likes>(settings.LikeCollectionName);
        }

        public likes Create(likes entity)
        {
            _like.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _like.DeleteOne(likes => likes.LikeId == id);

        }

        public List<likes> Get()
        {
            return _like.Find(like => true).ToList();
        }


        public long GetById(string id)
        {
            return _like.CountDocuments(like => like.ContentId == id);
        }


    }
}

