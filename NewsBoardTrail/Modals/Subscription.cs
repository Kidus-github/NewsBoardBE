using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Subscription
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubscriptionId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("subscription_type")]
        public string SubscriptionType { get; set; }
        [BsonElement("subscription_start_date")]
        public DateTime SubscriptionStartDate { get; set; }
        [BsonElement("subscription_end_date")]
        public DateTime SubscriptionEndDate { get; set; }
        [BsonElement("payment_status")]
        public string PaymentStatus { get; set; }

    }
}
