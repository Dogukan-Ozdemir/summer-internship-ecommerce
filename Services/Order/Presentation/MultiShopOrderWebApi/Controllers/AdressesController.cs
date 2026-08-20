using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers;
using MultiShopOrderApplication.Features.CQRS.Queries.AdressQueries;

namespace MultiShopOrderWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GEtAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        private readonly UpdateAdresssCommandHandler _updateAdresssCommandHandler;

        public AdressesController(GetAdressQueryHandler getAdressQueryHandler, GEtAdressByIdQueryHandler getAdressByIdQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler, UpdateAdresssCommandHandler updateAdresssCommandHandler)
        {
            _getAdressQueryHandler = getAdressQueryHandler;
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
            _updateAdresssCommandHandler = updateAdresssCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AdressList() { 
        var result = _getAdressQueryHandler.Handle();
        return Ok (result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> adressById(int id) {
            var result = await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command) { 
         await _createAdressCommandHandler.Handle(command); 
        return Ok("created");
        }
        [HttpPut]
        public async Task<IActionResult> UpgradeAdress(UpdateAdressCommand command) {
        await _updateAdresssCommandHandler.Handle(command);
        return Ok("upgraded"+command.AdressId);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id) {
            await _removeAdressCommandHandler.Handle(new RemoveAdressComnad(id));
            return Ok("deleted"+id);
        }


    }
}
