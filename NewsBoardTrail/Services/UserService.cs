using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{

    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _userCollection = database.GetCollection<User>(settings.UserCollectionName);
        }

        public User ValidateUserCredentials(string email, string password)
        {
            // Implement logic to validate user credentials and retrieve user from MongoDB
            return _userCollection.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
        }
    }
}
