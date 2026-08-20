using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IActionResult> BasketList()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBasketItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasketItem(BasketItemDto basketItemDto)
        {
            await _basketService.AddBasketItem(basketItemDto);
            return RedirectToAction(nameof(BasketList));
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItem(productId);
            return RedirectToAction(nameof(BasketList));
        }

        public async Task<IActionResult> DeleteBasket()
        {
            var basket = await _basketService.GetBasket();

            if (basket != null)
            {
                await _basketService.DeleteBasket(basket.UserId);
            }

            return RedirectToAction(nameof(BasketList));
        }
    }
}