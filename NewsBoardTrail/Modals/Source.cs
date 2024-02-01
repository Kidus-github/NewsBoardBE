using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Source
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SourceId { get; set; }
        [BsonElement("source_name")]
        public string SourceName { get; set; }
        [BsonElement("url")]
        public string URL { get; set; }
        [BsonElement("source_logo")]
        public string SourceLogo { get; set; }
    }
}
