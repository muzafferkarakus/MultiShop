using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
