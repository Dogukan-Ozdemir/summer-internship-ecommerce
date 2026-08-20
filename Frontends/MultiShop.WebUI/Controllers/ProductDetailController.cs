using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBasketService _basketService;

        public ProductDetailController(IHttpClientFactory httpClientFactory,
                                       IBasketService basketService)
        {
            _httpClientFactory = httpClientFactory;
            _basketService = basketService;
        }

        public IActionResult Index(string id, int quantity = 1)
        {
            ViewBag.Quantity = quantity;

            ViewBag.directory1 = "main page";
            ViewBag.directory2 = "product list";
            ViewBag.directory3 = "product detail";
            ViewBag.x = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(BasketItemDto basketItemDto)
        {
            await _basketService.AddBasketItem(basketItemDto);

            return RedirectToAction("Index", new
            {
                id = basketItemDto.ProductId,
                quantity = basketItemDto.Quantity
            });
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        // [HttpPost]
        /* public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
         {
             createCommentDto.ImageUrl = "test";
             createCommentDto.Rating = 1;
             createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
             createCommentDto.Status = false;
             createCommentDto.ProductId = "65dc67a7705038bfa8fb1f87";
             var client = _httpClientFactory.CreateClient();
             var jsonData = JsonConvert.SerializeObject(createCommentDto);
             StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
             var responseMessage = await client.PostAsync("https://localhost:7028/api/Comments", stringContent);
             if (responseMessage.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index", "Default");
             }
             return View();
         }*/
    }
}
