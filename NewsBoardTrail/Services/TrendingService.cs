using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class TrendingService : INewsBoardServices<Trendings>
    {
        private readonly IMongoCollection<Trendings> _trendingCollection;

        public TrendingService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _trendingCollection = database.GetCollection<Trendings>(settings.TrendingCollectionName);
        }

        public Trendings Create(Trendings entity)
        {
            _trendingCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _trendingCollection.DeleteOne(trending => trending.TrendingID == id);
        }

        public List<Trendings> Get()
        {
            return _trendingCollection.Find(trending => true).ToList();
        }

        public Trendings GetById(string id)
        {
            return _trendingCollection.Find(trending => trending.TrendingID == id).FirstOrDefault();
        }

        public void Update(string id, Trendings entity)
        {
            _trendingCollection.ReplaceOne(trending => trending.TrendingID == id, entity);
        }

    }
}
