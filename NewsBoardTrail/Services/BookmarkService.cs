using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class BookmarkService : INewsBoardServices<Bookmark>
    {
        private readonly IMongoCollection<Bookmark> _bookmark;
        public BookmarkService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _bookmark = database.GetCollection<Bookmark>(settings.BookmarkCollectionName);
        }

        public Bookmark Create(Bookmark entity)
        {
            _bookmark.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _bookmark.DeleteOne(bookmark => bookmark.BookmarkId == id);
        }

        public List<Bookmark> Get()
        {
            return _bookmark.Find(bookmark => true).ToList();
        }

        public Bookmark GetById(string id)
        {
            return _bookmark.Find(bookmark => bookmark.BookmarkId == id).FirstOrDefault();
        }

        public void Update(string id, Bookmark entity)
        {
            _bookmark.ReplaceOne(bookmark => bookmark.BookmarkId == id, entity);
        }
    }
}
