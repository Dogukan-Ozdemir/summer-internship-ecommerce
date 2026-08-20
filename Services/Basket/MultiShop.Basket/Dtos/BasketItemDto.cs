namespace MultiShop.Basket.Dtos
{
    public class BasketItemDto
    {
        public String ProductId { get; set; }
        public String ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }

    }
}
