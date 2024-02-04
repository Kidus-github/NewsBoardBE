using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class SearchHistoryService : INewsBoardServices<SearchHistory>
    {
        private readonly IMongoCollection<SearchHistory> _searchHistoryhCollection;

        public SearchHistoryService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _searchHistoryhCollection = database.GetCollection<SearchHistory>(settings.SearchHistoryCollectionName);
        }

        public SearchHistory Create(SearchHistory entity)
        {
            _searchHistoryhCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _searchHistoryhCollection.DeleteOne(searchHistory => searchHistory.SearchId == id);
        }

        public List<SearchHistory> Get()
        {
            return _searchHistoryhCollection.Find(searchHistory => true).ToList();
        }

        public SearchHistory GetById(string id)
        {
            return _searchHistoryhCollection.Find(searchHistory => searchHistory.SearchId == id).FirstOrDefault();
        }

        public void Update(string id, SearchHistory entity)
        {
            _searchHistoryhCollection.ReplaceOne(searchHistory => searchHistory.SearchId == id, entity);
        }

    }
}
