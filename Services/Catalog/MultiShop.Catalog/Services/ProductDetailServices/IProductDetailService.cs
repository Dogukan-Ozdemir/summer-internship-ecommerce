using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetail(CreateProductDetailsDto CreateproductDetailDtoAync);
        Task DeleteProductDetail(String id);
        Task UpdateProductDetail(UpdateProductDetailsDto UpdateproductDetailDtoAsync);
        Task<List<ResultProductDetailsDto>> GetAllProductsAsync();
        Task<GetByIdProductDetailDto> GetByIdProductAsync(String id);
    }
}
