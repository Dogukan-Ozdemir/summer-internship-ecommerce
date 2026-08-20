using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl { get; set; }



    }
}
