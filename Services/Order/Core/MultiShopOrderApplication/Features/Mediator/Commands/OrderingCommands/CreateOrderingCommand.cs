using MediatR;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands
{
    public class CreateOrderingCommand : IRequest<int>
    {
        public String UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; } 
    }
}
