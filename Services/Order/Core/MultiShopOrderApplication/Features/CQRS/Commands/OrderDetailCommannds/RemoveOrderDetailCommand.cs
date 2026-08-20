using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds
{
    public class RemoveOrderDetailCommand
    {
        public int id { get; set; }

        public RemoveOrderDetailCommand(int id)
        {
            this.id = id;
        }
    }
}
