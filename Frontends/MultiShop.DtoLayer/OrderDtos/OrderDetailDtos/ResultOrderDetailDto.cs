using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.DtoLayer.OrderDtos.OrderDetailDtos
{
    public class ResultOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public String ProductName { get; set; }
        public String ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
