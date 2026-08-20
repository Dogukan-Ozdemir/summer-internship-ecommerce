using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageSevices
{
    public interface IProductImageService
    {
        Task CreateProductImage(CreateProductImageDto CreateproductImageDtoAync);
        Task DeleteProductImage(String id);
        Task UpdateProductImage(UpdateProductImageDto UpdateproductImagetoAsync);
        Task<List<ResultProductImageDto>> GetAllProductsImageAsync();
        Task<GetByIdProductImageDto> GetByIdProductAsync(String id);
    }
}
