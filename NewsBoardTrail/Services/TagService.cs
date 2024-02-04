using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class TagService : INewsBoardServices<Tags>
    {
        private readonly IMongoCollection<Tags> _tagCollection;

        public TagService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _tagCollection = database.GetCollection<Tags>(settings.TagCollectionName);
        }

        public Tags Create(Tags entity)
        {
            _tagCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _tagCollection.DeleteOne(tag => tag.TagId == id);
        }

        public List<Tags> Get()
        {
            return _tagCollection.Find(tag => true).ToList();
        }

        public Tags GetById(string id)
        {
            return _tagCollection.Find(tag => tag.TagId == id).FirstOrDefault();
        }

        public void Update(string id, Tags entity)
        {
            _tagCollection.ReplaceOne(tag => tag.TagId == id, entity);
        }

    }
}
