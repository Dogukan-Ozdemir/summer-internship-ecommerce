using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;
using MultiShop.WebUI.Services.UserService;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderOderingService _orderOderingService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;

        public OrderController(
            IOrderOderingService orderOderingService,
            IOrderDetailService orderDetailService,
            IUserService userService)
        {
            _orderOderingService = orderOderingService;
            _orderDetailService = orderDetailService;
            _userService = userService;
        }

        public async Task<IActionResult> OrderList()
        {
            var user = await _userService.GetUserInfo();

            var values = await _orderOderingService.GetOrderingByUserId();

            return View(values);
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            var values = await _orderDetailService.GetOrderDetailsByOrderingId(id);

            return View(values);
        }
    }
}