using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int id { get; set; }

        public GetOrderDetailByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
