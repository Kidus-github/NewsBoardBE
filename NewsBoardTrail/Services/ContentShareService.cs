using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class ContentShareService : INewsBoardServices<ContentShare>
    {
        private readonly IMongoCollection<ContentShare> _contentShareCollection;

        public ContentShareService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _contentShareCollection = database.GetCollection<ContentShare>(settings.ContentShareCollectionName);
        }

        public ContentShare Create(ContentShare entity)
        {
            _contentShareCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {

            _contentShareCollection.DeleteOne(contentshare => contentshare.ShareID == id);

        }
        public List<ContentShare> Get() { 
           return _contentShareCollection.Find<ContentShare>(contentshare => true).ToList();
        }

        public ContentShare GetById(string id)
        {
           return _contentShareCollection.Find<ContentShare>(contentshare => contentshare.ShareID == id).FirstOrDefault();
        }

        public void Update(string id, ContentShare entity)
        {
            _contentShareCollection.ReplaceOne<ContentShare>(contentshare => contentshare.ShareID == id, entity);
        }
    }
}
