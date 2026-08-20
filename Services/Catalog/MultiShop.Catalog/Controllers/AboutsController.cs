using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _AboutService;
        public AboutsController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Aboutlist()
        {
            var result = await _AboutService.GetAllAboutAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(string id)
        {
            var result = await _AboutService.GetByIdAboutAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAbout)
        {
            await _AboutService.UpdateAboutAsyn(updateAbout);
            return Ok("updated");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAbout)
        {
            await _AboutService.CreateAboutAsyn(createAbout);
            return Ok("created About ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _AboutService.DeleteAboutAsyn(id);
            return Ok("deleted");
        }

    }
}
