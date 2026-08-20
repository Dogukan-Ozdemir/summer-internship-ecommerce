using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoCustomers
{
    public class CreateCargoCustomerDto
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

    }
}
