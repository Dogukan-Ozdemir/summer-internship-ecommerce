using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageServices : IProductImageServices

    {
        private readonly HttpClient _httpClient;
        public ProductImageServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImages", createProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("ProductImages?id=" + id);
        }
       public async Task<GetByIdProductImageDto?> GetByIdProductImageAsync(string id)
{
    var responseMessage = await _httpClient.GetAsync("ProductImages/" + id);

    if (!responseMessage.IsSuccessStatusCode)
    {
        return null;
    }

    return await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
}
        public async Task<List<ResultProductImageDto>> GetAllProductsImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ProductImages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImages", updateProductImageDto);
        }

        public async Task<GetByIdProductImageDto?> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("ProductImages/GetByIdProductAsync/" + id);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            return await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        }
    }
}
