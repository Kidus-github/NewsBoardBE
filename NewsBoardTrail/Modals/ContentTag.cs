using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class ContentTag
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContentTagId { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("tag_id")]
        public string TagId { get; set; }
    }
}
