using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.UserService;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {

        private readonly IUserService _userService;
        private readonly IProductImageServices _productImageService;

        public _TopbarUILayoutComponentPartial(
            IUserService userService,
            IProductImageServices productImageService)
        {
            _userService = userService;
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();

            if (user == null)
            {
                ViewBag.ProfileImage = "/MultiShop-Template/img/cool_Glasses_Guy.jpg";
                return View();
            }

            var image = await _productImageService.GetByIdProductAsync(user.Id);

            ViewBag.ProfileImage = image?.Image1 ?? "/MultiShop-Template/img/cool_Glasses_Guy.jpg";

            return View();
        }
    }
}
