using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class likes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string LikeId { get; set; }
        [BsonElement("user_id")]

        public string UserId { get; set; }
        [BsonElement("content_id")]

        public string ContentId { get; set; }
        [BsonElement("like_date")]

        public DateTime LikeDate { get; set; }
    }
}
