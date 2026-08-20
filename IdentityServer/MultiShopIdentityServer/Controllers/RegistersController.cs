using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopIdentityServer.Dtos;
using MultiShopIdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopIdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto registerDto)
        {
            var values = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.name,
                SurName = registerDto.SurName
            };

            var result = await _userManager.CreateAsync(values, registerDto.Password);

            if (result.Succeeded)
            {
                return Ok("User added successfully.");
            }

            return BadRequest(result.Errors.Select(x => x.Description));
        }
    }
}