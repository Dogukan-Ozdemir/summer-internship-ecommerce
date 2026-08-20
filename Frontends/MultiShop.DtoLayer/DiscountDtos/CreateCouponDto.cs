namespace MultiShop.DtoLayer.DiscountDtos
{
    public class CreateCouponDto
    {
        public String Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
        
    }
}
