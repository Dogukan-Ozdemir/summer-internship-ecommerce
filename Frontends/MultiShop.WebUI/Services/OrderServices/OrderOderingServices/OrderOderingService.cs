
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOderingServices
{
    public class OrderOderingService : IOrderOderingService
    {
        private readonly HttpClient _httpClient;
        public OrderOderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId()
        {
            //$"products/ProductListWithCategoryByCategoryId/{CategoryId}"
            var responseMessage = await _httpClient.GetAsync("Orderings/GetOrderingByUserId");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
        public async Task<int> CreateOrderingAsync(CreateOrderingDto createOrderingDto)
{
    var response = await _httpClient.PostAsJsonAsync("Orderings", createOrderingDto);

    var id = await response.Content.ReadFromJsonAsync<int>();

    return id;
}
    }
}