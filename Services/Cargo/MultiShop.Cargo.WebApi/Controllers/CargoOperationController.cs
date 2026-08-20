using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly IcargoOperationService _cargoService;

        public CargoOperationController(IcargoOperationService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {



            var result = new CargoOperation();

            result.Barcode = dto.Barcode;
            result.Description = dto.Description;
            result.OperationDate = dto.OperationDate;


            return Ok("cargo Operation created ");
        }

        [HttpDelete]
        public IActionResult CargoCustomerDelete(int id)
        {
            _cargoService.Tdelete(id);
            return Ok("cargo Operation deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GEtCargoCustomerById(int id)
        {
            var values = _cargoService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCargoOperationDto dto)
        {
           var result = new CargoOperation();
            result.Barcode = dto.Barcode;
            result.Description = dto.Description;   
            result.OperationDate = dto.OperationDate;
            result.CargoOperationId = dto.CargoOperationId;
            _cargoService.Tupdate(result);
            return Ok("cargo Operation updated");
        }
    }
}
