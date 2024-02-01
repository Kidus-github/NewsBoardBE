using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Bookmark
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookmarkId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("bookmark_date")]
        public DateTime BookmarkDate { get; set; }
    }
}
