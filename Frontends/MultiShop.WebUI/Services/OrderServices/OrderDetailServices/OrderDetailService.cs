using MultiShop.DtoLayer.OrderDtos.OrderDetailDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            await _httpClient.PostAsJsonAsync(
          "OrderDetail",
          createOrderDetailDto);

        }

        public async Task<List<ResultOrderDetailDto>> GetOrderDetailsByOrderingId(int id)
        {
            var response = await _httpClient.GetAsync($"OrderDetail/GetOrderDetailsByOrderingId/{id}");

            var values = await response.Content.ReadFromJsonAsync<List<ResultOrderDetailDto>>();

            return values;
        }
    }
}