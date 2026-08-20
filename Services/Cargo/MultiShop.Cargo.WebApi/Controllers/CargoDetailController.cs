using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomers;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoService;

        public CargoDetailController(ICargoDetailService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            
            

           var result = new CargoDetail();
            result.SenderCustomer = dto.SenderCustomer;
            result.ReceiverCustomer = dto.ReceiverCustomer;
            result.CargoCustumerId = dto.CargoCustumerId;
            result.Barcode = dto.Barcode;
            result.CargoCompanyId = dto.CargoCompanyId;
         
            return Ok("cargo Detail created ");
        }

        [HttpDelete]
        public IActionResult CargoCustomerDelete(int id)
        {
            _cargoService.Tdelete(id);
            return Ok("cargo Detail deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GEtCargoCustomerById(int id)
        {
            var values = _cargoService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCargoDetailDto dto)
        {
            var result = new CargoDetail();
            result.SenderCustomer = dto.SenderCustomer;
            result.ReceiverCustomer = dto.ReceiverCustomer;
            result.CargoCustumerId = dto.CargoCustumerId;
            result.Barcode = dto.Barcode;
            result.CargoCompanyId = dto.CargoCompanyId;
            result.CargoDetailId = dto.CargoDetailId;
            


            _cargoService.Tupdate(result);
            return Ok("cargo Detail updated");
        }
    }
}
