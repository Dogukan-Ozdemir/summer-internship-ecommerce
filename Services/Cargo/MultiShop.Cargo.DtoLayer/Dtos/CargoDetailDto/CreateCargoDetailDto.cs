using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDto
{
    public class CreateCargoDetailDto
    {
       
        public int CargoCustumerId { get; set; }
        public String SenderCustomer { get; set; }
        public String ReceiverCustomer { get; set; }
        public string Barcode { get; set; }
        public int CargoCompanyId { get; set; }
       
    }
}
