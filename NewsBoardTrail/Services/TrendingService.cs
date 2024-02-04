using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class TrendingService : INewsBoardServices<Trending>
    {
        private readonly IMongoCollection<Trending> _trendingCollection;

        public TrendingService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _trendingCollection = database.GetCollection<Trending>(settings.TrendingCollectionName);
        }

        public Trending Create(Trending entity)
        {
            _trendingCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _trendingCollection.DeleteOne(trending => trending.TrendingID == id);
        }

        public List<Trending> Get()
        {
            return _trendingCollection.Find(trending => true).ToList();
        }

        public Trending GetById(string id)
        {
            return _trendingCollection.Find(trending => trending.TrendingID == id).FirstOrDefault();
        }

        public void Update(string id, Trending entity)
        {
            _trendingCollection.ReplaceOne(trending => trending.TrendingID == id, entity);
        }

    }
}
