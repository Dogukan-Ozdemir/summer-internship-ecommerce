using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingCommnad:IRequest
    {
        public int id { get; set; }

        public RemoveOrderingCommnad(int id)
        {
            this.id = id;
        }
    }
}
