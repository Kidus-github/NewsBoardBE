using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class NotificationService : INewsBoardServices<Notification>
    {
        private readonly IMongoCollection<Notification> _notificationCollection;

        public NotificationService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _notificationCollection = database.GetCollection<Notification>(settings.NotificationCollectionName);
        }

        public Notification Create(Notification entity)
        {
            _notificationCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {

            _notificationCollection.DeleteOne(notification => notification.NotificationID == id);

        }
        public List<Notification> Get()
        {
            return _notificationCollection.Find<Notification>(notification => true).ToList();
        }

        public Notification GetById(string id)
        {
            return _notificationCollection.Find<Notification>(notification => notification.NotificationID == id).FirstOrDefault();
        }

        public void Update(string id, Notification entity)
        {
            _notificationCollection.ReplaceOne<Notification>(notification => notification.NotificationID == id, entity);
        }
    }
}
