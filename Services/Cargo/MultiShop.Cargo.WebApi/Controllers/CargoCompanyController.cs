using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompaniesDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            var result = new CargoCompany(); 
            result.CargoCompanyName = dto.CargoCompanyName;
            _cargoCompanyService.Tinsert(result);
            return Ok("cargo company created ");
        }

        [HttpDelete]
        public IActionResult CargoCompanyDelete(int id)
        {
            _cargoCompanyService.Tdelete(id);
            return Ok("cargo company deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GEtCargoCompanyById(int id)
        {
          var values =  _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCompany(UpdateCargoCompanyDto dto)
        {
            var result = new CargoCompany();
            result.CargoCompanyName=dto.CargoCompanyName;
            result.CargoCompanyId=dto.CargoCompanyId;
            _cargoCompanyService.Tupdate(result);
            return Ok ("cargo company updated");
        }
    }
}
