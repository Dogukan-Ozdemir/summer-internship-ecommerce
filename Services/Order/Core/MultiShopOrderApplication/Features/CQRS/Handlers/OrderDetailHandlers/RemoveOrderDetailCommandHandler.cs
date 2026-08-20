using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _Repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand removeCommnad)
        {
            var result = (await _Repository.GetByIdAsync(removeCommnad.id));
            await _Repository.DeleteAsync(result);
        }
    }
}
