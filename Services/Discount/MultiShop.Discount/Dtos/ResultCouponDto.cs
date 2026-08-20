namespace MultiShop.Discount.Dtos
{
    public class ResultCouponDto
    {
        public int CouponId { get; set; }
        public String Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
        
    }
}
