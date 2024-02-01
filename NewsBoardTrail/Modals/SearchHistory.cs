using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class SearchHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SearchId { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("search_query")]
        public string SearchQuery { get; set; }
        [BsonElement("search_date")]
        public DateTime SearchDate { get; set; }
    }
}
