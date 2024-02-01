using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CommentId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("comment_text")]
        public string CommentText { get; set; }
        [BsonElement("comment_date")]
        public DateTime CommentDate { get; set; }
    }
}
