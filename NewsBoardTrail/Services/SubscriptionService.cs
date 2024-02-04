using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class SubscriptionService: INewsBoardServices<Subscription>
    {
        private readonly IMongoCollection<Subscription> _subscriptionCollection;

        public SubscriptionService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _subscriptionCollection = database.GetCollection<Subscription>(settings.SubscripitonCollectionName);
        }

        public Subscription Create(Subscription entity)
        {
            _subscriptionCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _subscriptionCollection.DeleteOne(subscription => subscription.SubscriptionId == id);
        }

        public List<Subscription> Get()
        {
            return _subscriptionCollection.Find(subscription => true).ToList();
        }

        public Subscription GetById(string id)
        {
            return _subscriptionCollection.Find(subscription => subscription.SubscriptionId == id).FirstOrDefault();
        }

        public void Update(string id, Subscription entity)
        {
            _subscriptionCollection.ReplaceOne(subscription => subscription.SubscriptionId == id, entity);
        }

    }
}
