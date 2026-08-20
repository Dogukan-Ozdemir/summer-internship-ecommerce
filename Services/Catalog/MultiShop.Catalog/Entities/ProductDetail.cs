using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String ProductDetailsId { get; set; }
        public String ProductDescription { get; set; }
        public String ProductInfo { get; set; }
        public String ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
