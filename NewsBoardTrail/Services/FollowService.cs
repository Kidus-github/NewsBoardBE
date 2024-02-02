using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class FollowService : INewsBoardServices<Follow>
    {
        private readonly IMongoCollection<Follow> _follow;

        public FollowService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient) {
            var database= mongoClient.GetDatabase(settings.DatabaseName);

            _follow = database.GetCollection<Follow>(settings.FollowCollectionName);
        }

        public Follow Create(Follow entity)
        {
            _follow.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _follow.DeleteOne(follow => follow.FollowId == id);
        }

        public List<Follow> Get()
        {
            return _follow.Find<Follow>(follow => true).ToList();
        }

        public Follow GetById(string id)
        {
            return _follow.Find<Follow>(follow => follow.FollowId == id).FirstOrDefault();
        }

        public void Update(string id, Follow entity)
        {
            _follow.ReplaceOne<Follow>(follow => follow.FollowId == id, entity);
        }
    }
}
