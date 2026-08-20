using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageSevices;

namespace MultiShop.Catalog.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetaillist()
        {
            var result = await _ProductImageService.GetAllProductsImageAsync();
            return Ok(result);
        }

        [HttpGet("GetByIdProductAsync/{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var result = await _ProductImageService.GetByIdProductAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductImageDto updateProductImage)
        {
            await _ProductImageService.UpdateProductImage(updateProductImage);
            return Ok("updated");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductImageDto createProductImage)
        {
            await _ProductImageService.CreateProductImage(createProductImage);
            return Ok("created images ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductImageService.DeleteProductImage(id);
            return Ok("deleted");
        }


    }
}
