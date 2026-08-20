using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageServices
    {
        Task CreateProductImageAsync(CreateProductImageDto CreateproductImageDtoAync);
        Task DeleteProductImageAsync(String id);
        Task UpdateProductImageAsync(UpdateProductImageDto UpdateproductImagetoAsync);
        Task<List<ResultProductImageDto>> GetAllProductsImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductAsync(String id);
    }
}
