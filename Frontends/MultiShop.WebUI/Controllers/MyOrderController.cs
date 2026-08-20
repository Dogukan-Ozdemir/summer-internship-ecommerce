using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShop.WebUI.Services.OrderServices.OrderOderingServices;
using MultiShop.WebUI.Services.UserService;

namespace MultiShop.WebUI.Controllers
{
    public class MyOrderController : Controller
    {
        private readonly IOrderOderingService _orderOderingService;
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;

        public MyOrderController(
            IOrderOderingService orderOderingService,
            IUserService userService,
           IOrderDetailService orderDetailService)
        {
            _orderOderingService = orderOderingService;
            _userService = userService;
            _orderDetailService = orderDetailService;
        }

           public async Task<IActionResult> Index()
          {
              var user = await _userService.GetUserInfo();

              var values = await _orderOderingService.GetOrderingByUserId();

              return View(values);
          }

        public async Task<IActionResult> Detail(int id)
        {
            var values = await _orderDetailService.GetOrderDetailsByOrderingId(id);

            return View(values);
        }

       
    }
}