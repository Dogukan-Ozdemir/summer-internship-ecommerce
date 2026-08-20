using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoCompaniesDto
{
    public class UpdateCargoCompanyDto
    {
        public string CargoCompanyName { get; set; }
        public int CargoCompanyId { get; set; }
        public string ImageUrl { get; set; }
    }
}
