using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompaniesDto;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomers;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCostumerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCostumerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var result = new CargoCustomer();
            result.PhoneNumber = dto.PhoneNumber;
            result.City = dto.City;
            result.District = dto.District;
            result.Address = dto.Address;
            result.Email = dto.Email;
            result.Surname = dto.Surname;
            
            _cargoCustomerService.Tinsert(result);
            return Ok("cargo Customer created ");
        }

        [HttpDelete]
        public IActionResult CargoCustomerDelete(int id)
        {
            _cargoCustomerService.Tdelete(id);
            return Ok("cargo Customer deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GEtCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCargoCustomerDto dto)
        {
            var result = new CargoCustomer();
            result.PhoneNumber = dto.PhoneNumber;
            result.City = dto.City;
            result.District = dto.District;
            result.Address = dto.Address;
            result.Email = dto.Email;
            result.Surname = dto.Surname;
            result.CargoCustomerId = dto.CargoCustomerId;
            _cargoCustomerService.Tupdate(result);
            return Ok("cargo Customer updated");
        }
    }
}
