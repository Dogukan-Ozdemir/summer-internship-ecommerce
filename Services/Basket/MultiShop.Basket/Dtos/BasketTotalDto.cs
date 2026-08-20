namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public String UserId { get; set; }
        public  String? DiscountCode { get; set; }
        public int DiscountId { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }


    }
}
