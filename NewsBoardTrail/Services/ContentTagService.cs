using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class ContentTagService : INewsBoardServices<ContentTag>
    {
        private readonly IMongoCollection<ContentTag> _contentTagCollection;

        public ContentTagService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _contentTagCollection = database.GetCollection<ContentTag>(settings.ContentTagCollectionName);
        }
        public ContentTag Create(ContentTag entity)
        {
            _contentTagCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _contentTagCollection.DeleteOne(contentshare => contentshare.ContentTagId == id);
        }

        public List<ContentTag> Get()
        {
            return _contentTagCollection.Find<ContentTag>(contentshare => true).ToList();

        }

        public ContentTag GetById(string id)
        {
            return _contentTagCollection.Find<ContentTag>(contenttag => contenttag.ContentTagId == id).FirstOrDefault();
        }

        public void Update(string id, ContentTag entity)
        {
            _contentTagCollection.ReplaceOne<ContentTag>(contenttag => contenttag.ContentTagId == id, entity);
        }
    }
}
