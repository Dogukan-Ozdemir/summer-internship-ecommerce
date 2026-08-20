using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds
{
    public class CreateOrderDetailCommand
    {
        public String ProductName { get; set; }
        public String ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
