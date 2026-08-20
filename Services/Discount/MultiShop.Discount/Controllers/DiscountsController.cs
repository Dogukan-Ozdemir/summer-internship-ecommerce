using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IdiscountService _discountService;

        public DiscountsController(IdiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoupon() {
            var result =await _discountService.GetAllDiscountCouponAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id) {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("deleted");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon(int id) { 
        var result= await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto couponDto)
        {
            await _discountService.CreateDiscountCouponAsync(couponDto);
            return Ok("created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto couponDto) { 
        await _discountService.UpdateDiscountCouponAsync(couponDto);
            return Ok("updated");
        }

    }
}
