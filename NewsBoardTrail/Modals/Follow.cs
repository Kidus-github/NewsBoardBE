using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Follow
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FollowId { get; set; }
        [BsonElement("follower_user_id")]
        public string FollowerUserId { get; set; }
        [BsonElement("followed_user_id")]
        public string FollowedUserId { get; set; }
        [BsonElement("follow_date")]
        public DateTime FollowDate { get; set; }
    }
}
