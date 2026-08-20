using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsyn(CreateCategoryDto CreateCategoryDto);
        Task DeleteCategoryAsyn(String id);
        Task UpdateCategoryAsyn(UpdateCategoryDto UpdateCategoryDto);
        Task<GetByCategoryIDto> GetByIdCategoryAsync(String id);
    }
}
