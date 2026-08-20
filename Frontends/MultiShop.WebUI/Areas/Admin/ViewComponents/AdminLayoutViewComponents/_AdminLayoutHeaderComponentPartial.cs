using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.UserService;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;

        public _AdminLayoutHeaderComponentPartial(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();

            if (user != null)
            {
                ViewBag.userName = $"{user.Name} {user.Surname}";
            }
            else
            {
                ViewBag.userName = "Admin User";
            }

            // Temporary demo values
            ViewBag.messageCount = 5;
            ViewBag.totalCommentCount = 12;

            return View();
        }
    }
}