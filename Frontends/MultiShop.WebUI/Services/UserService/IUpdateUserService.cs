using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.UserService
{
    public interface IUpdateUserService
    {
        Task UpdateUser(UserDetailViewModel model);
    }
}