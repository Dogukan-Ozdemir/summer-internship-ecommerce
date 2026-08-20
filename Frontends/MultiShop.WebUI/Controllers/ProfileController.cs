using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.UserService;

namespace MultiShop.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUpdateUserService _updateUserService;
        private readonly IProductImageServices _productImageService;

        public ProfileController(IUserService userService, IUpdateUserService updateUserService, IProductImageServices productImageService)
        {
            _userService = userService;
            _updateUserService = updateUserService;
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();

            var image = await _productImageService.GetByIdProductAsync(values.Id);

            if (image == null)
            {
                await _productImageService.CreateProductImageAsync(new CreateProductImageDto
                {
                    ProductId = values.Id,
                    Image1 = "/MultiShop-Template/img/cool_Glasses_Guy.jpg",
                    Image2 = "",
                    Image3 = ""
                });

                image = await _productImageService.GetByIdProductAsync(values.Id);
            }

            ViewBag.ProfileImage = image.Image1;

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(model);
            }

            await _updateUserService.UpdateUser(model);

            await _updateUserService.UpdateUser(model);

            TempData["Success"] = "Your profile has been updated successfully. Please sign in again.";

            return RedirectToAction("Index", "Profile");


        }

        [HttpGet]
        public IActionResult SelectAvatar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectAvatar(string imagePath)
        {
            var user = await _userService.GetUserInfo();

            var image = await _productImageService.GetByIdProductAsync(user.Id);

            if (image != null)
            {
                await _productImageService.DeleteProductImageAsync(image.ProductImageId);
            }

            await _productImageService.CreateProductImageAsync(new CreateProductImageDto
            {
                ProductId = user.Id,
                Image1 = imagePath,
                Image2 = "",
                Image3 = ""
            });

            return RedirectToAction("Index", "Profile");
        }
    }
}

    