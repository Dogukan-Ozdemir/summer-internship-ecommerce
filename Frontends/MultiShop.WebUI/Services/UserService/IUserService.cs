using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.UserService
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task UpdateUser(UserDetailViewModel model);
    }
}