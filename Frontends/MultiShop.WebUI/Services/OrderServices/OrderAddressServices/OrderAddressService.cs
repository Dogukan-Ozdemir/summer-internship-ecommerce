using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;       //hello traveler have a rest, you deserved it.
        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
             await _httpClient.PostAsJsonAsync(
                "Adresses",
                createOrderAddressDto);

           
        }
    }
}
