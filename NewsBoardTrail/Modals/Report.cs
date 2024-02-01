using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewsBoardBE.Modals
{
    public class Report
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportId { get; set; }
        [BsonElement("reporter_id")]
        public string ReporterId { get; set; }
        [BsonElement("content_id")]
        public string ContentID { get; set; }
        [BsonElement("report_type")]
        public string ReportType { get; set; }
        [BsonElement("report_description")]
        public string ReportDescription { get; set; }
        [BsonElement("report_date")]
        public DateTime ReportDate { get; set; }
        [BsonElement("report_status")]
        public string ReportStatus { get; set; }
    }
}
