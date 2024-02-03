
using MongoDB.Driver;
using NewsBoardBE.Modals;

namespace NewsBoardBE.Services
{
    public class PaymentTransactionService : INewsBoardServices<PaymentTransaction>
    {
        private readonly IMongoCollection<PaymentTransaction> _paymentTransactionCollection;

        public PaymentTransactionService(INewsBoardDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _paymentTransactionCollection = database.GetCollection<PaymentTransaction>(settings.PaymentTransactionCollectionName);
        }

        public PaymentTransaction Create(PaymentTransaction entity)
        {
            _paymentTransactionCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {

            _paymentTransactionCollection.DeleteOne(paymentTransaction => paymentTransaction.TransactionId == id);

        }
        public List<PaymentTransaction> Get()
        {
            return _paymentTransactionCollection.Find<PaymentTransaction>(paymentTransaction => true).ToList();
        }

        public PaymentTransaction GetById(string id)
        {
            return _paymentTransactionCollection.Find<PaymentTransaction>(paymentTransaction => paymentTransaction.TransactionId == id).FirstOrDefault();
        }

        public void Update(string id, PaymentTransaction entity)
        {
            _paymentTransactionCollection.ReplaceOne<PaymentTransaction>(paymentTransaction => paymentTransaction.TransactionId == id, entity);
        }
    }
}
