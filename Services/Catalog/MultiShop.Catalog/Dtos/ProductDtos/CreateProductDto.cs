namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public String ProductName { get; set; }
        public decimal ProductPrize { get; set; }
        public String ProductImageUrl { get; set; }
        public String ProductDescription { get; set; }
        public String CategoryId { get; set; }
    }
}
