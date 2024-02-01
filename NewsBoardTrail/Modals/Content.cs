using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Content
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContentId { get; set; }=string.Empty;

        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("url")]
        public string URL { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("publication_date")]
        public DateTime PublicationDate { get; set; }
        [BsonElement("category_id")]
        public string CategoryId { get; set; }
        [BsonElement("image")]
        public List<string> Image { get; set; }
        [BsonElement("video")]
        public string Video { get; set; }
        [BsonElement("content_type")]
        public string ContentType { get; set; }
        [BsonElement("keyword")]
        public List<string> Keywords { get; set; }
        [BsonElement("content_tags")]
        public List<string> ContentTags { get; set; }
        [BsonElement("content_like")]
        public int ContentLike { get; set; }
        [BsonElement("content_views")]
        public int ContentViews { get; set; }
        [BsonElement("content_comment")]
        public int ContentComment { get; set; }
        [BsonElement("date_created")]
        public DateTime DateCreated { get; set; }
    }
}
