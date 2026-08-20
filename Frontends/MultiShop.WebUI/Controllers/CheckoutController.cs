using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.DtoLayer.OrderDtos.OrderDetailDtos;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;


namespace MultiShop.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderOderingService _orderOderingService;
        private readonly IOrderAddressService _orderAddressService;
        private readonly IOrderDetailService _orderDetailService;
        public CheckoutController(IBasketService basketService, IOrderOderingService orderOderingService, IOrderAddressService orderAddressService, IOrderDetailService orderDetailService)
        {
            _basketService = basketService;
            _orderOderingService = orderOderingService;
            _orderAddressService = orderAddressService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var basket = await _basketService.GetBasket();

            CheckoutViewModel model = new CheckoutViewModel();

            model.Basket = basket;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {

            var basket = await _basketService.GetBasket();
            var createOrdering = new CreateOrderingDto
            {
                UserId = basket.UserId,
                TotalPrice = basket.TotalPrice,
                OrderDate = DateTime.Now
            };
            int orderingId = await _orderOderingService.CreateOrderingAsync(createOrdering);

            var createAddress = new CreateOrderAddressDto
            {
                UserId = basket.UserId,
                City = model.City,
                District = model.District,
                Detail = model.Detail, 

            };

            await _orderAddressService.CreateOrderAddressAsync(createAddress);
            foreach (var item in basket.BasketItems)
            {
                var createOrderDetail = new CreateOrderDetailDto
                {
                    OrderingId = orderingId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductPrice = item.Price,
                    ProductAmount = item.Quantity,
                    ProductTotalPrice = item.Price * item.Quantity
                };

                await _orderDetailService.CreateOrderDetailAsync(createOrderDetail);
            }

            model.Basket = basket;
            await _basketService.DeleteBasket(basket.UserId);
            return View(model);

        }
    }
}
