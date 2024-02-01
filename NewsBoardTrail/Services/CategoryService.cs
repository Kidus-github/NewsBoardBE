using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class CategoryService :INewsBoardServices<Category>
    {
        private readonly IMongoCollection<Category> _category;

        public CategoryService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _category = database.GetCollection<Category>(settings.CategoryCollectionName);
        }
        public Category Create(Category entity)
        {
            _category.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _category.DeleteOne(category => category.CategoryId == id);

        }

        public List<Category> Get()
        {
            return _category.Find(category => true).ToList();
        }

        public Category GetById(string id)
        {
            return _category.Find(category => category.CategoryId == id).FirstOrDefault();
        }

        public void Update(string id, Category entity)
        {
            _category.ReplaceOne(category => category.CategoryId == id, entity);
        }
    }
}
