using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Tag
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TagId { get; set; }
        [BsonElement("tag_name")]
        public string TagName { get; set; }
    }
}
