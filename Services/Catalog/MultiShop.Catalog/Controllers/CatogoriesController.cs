using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatogoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CatogoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> categorylist()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetByIdCategory(string id){
            var result = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updatecategory)
        {
            await _categoryService.UpdateCategoryAsyn(updatecategory);
            return Ok("updated");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createcategory) {
            await _categoryService.CreateCategoryAsyn(createcategory);
            return Ok("created category ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id) { 
        await _categoryService.DeleteCategoryAsyn(id);
            return Ok("deleted");
        }




    }
}
