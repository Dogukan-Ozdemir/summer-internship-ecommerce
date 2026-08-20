using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopIdentityServer.Models;
using System;
using System.Threading.Tasks;

namespace MultiShopIdentityServer.Controllers
{
    [Route("api/updateuser")]
    [ApiController]
    public class UpdateUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateUserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto model)
        {
            Console.WriteLine("UPDATE USER HIT");
            Console.WriteLine(model.Id);
            Console.WriteLine(model.Username);
            Console.WriteLine(model.Email);

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            }

            user.UserName = model.Username;
            user.Email = model.Email;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User updated");
        }
    }
}