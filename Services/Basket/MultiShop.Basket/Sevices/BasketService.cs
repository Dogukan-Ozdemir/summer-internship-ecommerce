using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Sevices
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }


        public async Task DeleteBasket(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return;
            }

            await _redisService.GetDb()
                .KeyDeleteAsync(userId);
        }



        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            Console.WriteLine("========== BASKET DEBUG ==========");
            Console.WriteLine($"USER ID: {userId}");
            Console.WriteLine("=================================");


            // TEMP BYPASS
            // If somehow claim is missing
            if (string.IsNullOrEmpty(userId))
            {
                userId = "1";
            }



            var existBasket = await _redisService
                .GetDb()
                .StringGetAsync(userId);



            if (existBasket.IsNullOrEmpty)
            {
                Console.WriteLine("No basket found. Creating empty basket.");


                var emptyBasket = new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                   
                };


                await SaveBasket(emptyBasket);


                return emptyBasket;
            }



            Console.WriteLine($"REDIS DATA: {existBasket}");



            try
            {
                var basket = JsonSerializer.Deserialize<BasketTotalDto>(
                    existBasket.ToString()
                );


                if (basket == null)
                {
                    return new BasketTotalDto
                    {
                        UserId = userId,
                        BasketItems = new List<BasketItemDto>()
                        
                    };
                }


                return basket;
            }
            catch (Exception ex)
            {
                Console.WriteLine("REDIS JSON ERROR:");
                Console.WriteLine(ex.Message);


                return new BasketTotalDto
                {
                    UserId = userId,
                    BasketItems = new List<BasketItemDto>()
                   
                };
            }
        }



        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService
                .GetDb()
                .StringSetAsync(
                    basket.UserId,
                    JsonSerializer.Serialize(basket)
                );
        }
    }
}