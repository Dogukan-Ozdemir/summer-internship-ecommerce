using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task CreateAboutAsyn(CreateAboutDto CreateCategoryDto);
        Task DeleteAboutAsyn(String id);
        Task UpdateAboutAsyn(UpdateAboutDto UpdateCategoryDto);
        Task<GetByIdAboutDto> GetByIdAboutAsync(String id);
    }
}
