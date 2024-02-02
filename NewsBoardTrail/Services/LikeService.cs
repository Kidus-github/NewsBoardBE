using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class LikeService
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

       /* public long GetCount()
        {
            return _like.Find(like => true).Count();
        }
       */
        public likes GetById(string id)
        {
            return _like.Find(like => like.LikeId == id).FirstOrDefault();
        }


    }
}

