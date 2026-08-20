using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IdiscountService
    {
        Task<List<ResultCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code);
        int GetDiscountCouponCountRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}