using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using MultiShop.WebUI.Models;


namespace MultiShop.WebUI.Services.UserService
    {
        public class UserService : IUserService
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly HttpClient _httpClient;

        public UserService(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
        }

        public Task<UserDetailViewModel> GetUserInfo()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity!.IsAuthenticated)
            {
                return Task.FromResult<UserDetailViewModel>(null!);
            }

            var values = new UserDetailViewModel
            {
                Id = user.FindFirst("sub")?.Value,
                Username = user.FindFirst("name")?.Value,
                Email = user.FindFirst("email")?.Value,
                Name = user.FindFirst("given_name")?.Value,
                Surname = user.FindFirst("family_name")?.Value // Your token doesn't contain this, so it'll be null.
            };

            return Task.FromResult(values);
        }

        public async Task UpdateUser(UserDetailViewModel model)
        {
            await _httpClient.PutAsJsonAsync("users", model);
        }
    }
    }
    


