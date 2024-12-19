﻿using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
