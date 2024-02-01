using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class ContentShare
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShareID { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("share_type")]
        public string ShareType { get; set; }
        [BsonElement("share_date")]
        public DateTime ShareDate { get; set; }
    }
}
