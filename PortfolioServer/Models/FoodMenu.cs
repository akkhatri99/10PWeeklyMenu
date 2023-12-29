using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioServer.Models
{
    [CollectionName("FoodMenu")]
    public class FoodMenu : MongoEntity
    {
        [BsonElement("Day")]
        public string? Day { get; set; }
        [BsonElement("Date")]
        public DateTime? Date { get; set; }
        [BsonElement("Item")]
        public string? Item { get; set; }
        [BsonElement("LikeCount")]
        public int? LikeCount { get; set; } = 0;
        [BsonElement("DisLikeCount")]
        public int? DislikeCount { get; set; } = 0;
        [BsonElement("Image")]
        public string? Image { get; set; }
    }
}
