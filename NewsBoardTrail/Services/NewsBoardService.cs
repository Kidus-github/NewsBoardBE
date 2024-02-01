using MongoDB.Driver;
using NewsBoardBE.Modals;


namespace NewsBoardBE.Services
{
    public class NewsBoardService : INewsBoardServices<User>
    {
        private readonly IMongoCollection<User> _user;

        public NewsBoardService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
        }
        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Delete(string id)
        {

            _user.DeleteOne(user => user.UserId == id);
        }

        public List<User> Get()
        {
            return _user.Find(user => true).ToList();
        }

        public User GetById(string id)
        {
            return _user.Find(user => user.UserId == id).FirstOrDefault();
        }

        public void Update(string id, User user)
        {
            _user.ReplaceOne(user => user.UserId == id, user);
        }
    }
}
