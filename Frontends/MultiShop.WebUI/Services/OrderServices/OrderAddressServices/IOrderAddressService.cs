using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {

        //maybe return to this way. prob not
        // Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //    Task DeleteAboutAsync(string id);
        //    Task<UpdateAboutDto> GetByIdAboutAsync(string id);
    }
}