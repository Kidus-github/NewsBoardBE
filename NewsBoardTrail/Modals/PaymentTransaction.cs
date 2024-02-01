using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class PaymentTransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TransactionId { get; set; }
        [BsonElement("user_id")]
        public string UserID { get; set; }
        [BsonElement("amount")]
        public double Amount { get; set; }
        [BsonElement("transaction_date")]
        public DateTime TransactionDate { get; set; }
        [BsonElement("payment_method")]
        public string PaymentMethod { get; set; }
        [BsonElement("transaction_status")]
        public string TransactionStatus { get; set; }
        [BsonElement("transaction_type")]
        public string TransactionType { get; set; }
    }
}
