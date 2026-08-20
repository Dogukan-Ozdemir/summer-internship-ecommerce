using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String ProductImageId { get; set; }
        public String Image1 { get; set; }
        public String Image2 { get; set; }
        public String Image3 { get; set; }
        public String ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }

    }
}
