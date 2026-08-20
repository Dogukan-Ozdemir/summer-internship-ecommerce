using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductServices
    {
        Task CreateProductAsync(CreateProductDto CreateproductDtoAync);
        Task DeleteProductAsync(String id);
        Task UpdateProductAsync(UpdateProductDto UpdateproducttoAsync);
        Task<List<ResultProductDto>> GetAllProductsAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(String id);
        public Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
        public Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    }
}
