using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos
{
    public class CreateOrderingDto
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
