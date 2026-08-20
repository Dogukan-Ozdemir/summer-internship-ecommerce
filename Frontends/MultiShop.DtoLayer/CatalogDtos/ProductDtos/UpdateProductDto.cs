namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class UpdateProductDto
    {
        public String ProductId { get; set; }
        public String ProductName { get; set; }
        public decimal ProductPrize { get; set; }
        public String ProductImageUrl { get; set; }
        public String ProductDescription { get; set; }
        public String CategoryId { get; set; }
    }
}
