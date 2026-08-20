using MultiShop.DtoLayer.OrderDtos.OrderDetailDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto);
        Task<List<ResultOrderDetailDto>> GetOrderDetailsByOrderingId(int id);
    }
}