using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class ContentService: INewsBoardServices<Content>
    {
        private readonly IMongoCollection<Content> _content;

        public ContentService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _content = database.GetCollection<Content>(settings.ContentCollectionName);
        }

        public Content Create(Content entity)
        {
            _content.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _content.DeleteOne(content => content.ContentId == id);

        }

        public List<Content> Get()
        {
           return _content.Find(content => true).ToList();
        }

        public Content GetById(string id)
        {
            return _content.Find(content => content.ContentId == id).FirstOrDefault();
        }

        public void Update(string id, Content entity)
        {
            _content.ReplaceOne(content => content.ContentId == id, entity);
        }
    }
}
