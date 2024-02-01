using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Trending
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TrendingID { get; set; }
        [BsonElement("content_id")]
        public string ContentId { get; set; }
        [BsonElement("engagment_count")]
        public int EngagmentCount { get; set; }
        [BsonElement("trending_date")]
        public DateTime TrendingDate { get; set; }
    }
}
