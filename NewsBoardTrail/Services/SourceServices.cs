using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class SourceServices : INewsBoardServices<Source>
    {
        private readonly IMongoCollection<Source> _sourceCollection;

        public SourceServices(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _sourceCollection = database.GetCollection<Source>(settings.SourceCollectionName);
        }

        public Source Create(Source entity)
        {
            _sourceCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _sourceCollection.DeleteOne(source => source.SourceId == id);
        }

        public List<Source> Get()
        {
            return _sourceCollection.Find(source => true).ToList();
        }

        public Source GetById(string id)
        {
            return _sourceCollection.Find(source => source.SourceId == id).FirstOrDefault();
        }

        public void Update(string id, Source entity)
        {
            _sourceCollection.ReplaceOne(source => source.SourceId == id, entity);
        }

    }
}