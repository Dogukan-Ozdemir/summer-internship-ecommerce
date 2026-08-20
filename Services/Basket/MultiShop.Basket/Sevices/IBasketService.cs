using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Sevices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(String UserId);
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(String UserId);


    }
}
