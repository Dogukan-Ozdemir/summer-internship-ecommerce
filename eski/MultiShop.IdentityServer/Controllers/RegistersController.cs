using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
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
SurName = registerDto.SurName,
            };
            var result =_userManager.CreateAsync(values,registerDto.Password);
            if (result.IsCompletedSuccessfully) {
                return Ok("user added successfully"); }
            else { return Ok("error happened please try again"); }
        }
    }
}
