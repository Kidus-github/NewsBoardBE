using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class TagService : INewsBoardServices<Tag>
    {
        private readonly IMongoCollection<Tag> _tagCollection;

        public TagService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _tagCollection = database.GetCollection<Tag>(settings.TagCollectionName);
        }

        public Tag Create(Tag entity)
        {
            _tagCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _tagCollection.DeleteOne(tag => tag.TagId == id);
        }

        public List<Tag> Get()
        {
            return _tagCollection.Find(tag => true).ToList();
        }

        public Tag GetById(string id)
        {
            return _tagCollection.Find(tag => tag.TagId == id).FirstOrDefault();
        }

        public void Update(string id, Tag entity)
        {
            _tagCollection.ReplaceOne(tag => tag.TagId == id, entity);
        }

    }
}
