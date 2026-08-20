using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderDomain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public String UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }


    }
}
