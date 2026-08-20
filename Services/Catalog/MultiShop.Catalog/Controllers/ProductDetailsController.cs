using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetaillist()
        {
            var result = await _ProductDetailService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var result = await _ProductDetailService.GetByIdProductAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDetailsDto updateProductDetail)
        {
            await _ProductDetailService.UpdateProductDetail(updateProductDetail);
            return Ok("updated");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDetailsDto createProductDetail)
        {
            await _ProductDetailService.CreateProductDetail(createProductDetail);
            return Ok("created ProductDetail ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductDetailService.DeleteProductDetail(id);
            return Ok("deleted");
        }


    }
}
