using System.Net.Http.Json;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.UserService
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly HttpClient _httpClient;

        public UpdateUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task UpdateUser(UserDetailViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                "https://localhost:5001/api/UpdateUser",
                new
                {
                    Id = model.Id,
                    Username = model.Username,
                    Email = model.Email,
                  //  surname=model.Surname
                });


            response.EnsureSuccessStatusCode();
        }
    }
}