using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Notification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string NotificationID { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("notification_type")]
        public string NotificationType { get; set; }
        [BsonElement("notification_date")]
        public string NotificationDate { get; set; }
        [BsonElement("read_status")]
        public string ReadStatus { get; set; }
    }
}
