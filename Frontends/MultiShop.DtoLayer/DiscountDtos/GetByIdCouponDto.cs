namespace MultiShop.DtoLayer.DiscountDtos
{
    public class GetByIdCouponDto
    {
        public int CouponId { get; set; }
        public String Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
        
    }
}
