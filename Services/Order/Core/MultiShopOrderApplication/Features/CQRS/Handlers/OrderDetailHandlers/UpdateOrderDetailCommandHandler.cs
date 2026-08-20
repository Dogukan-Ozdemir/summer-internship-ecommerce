using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpgradeOrderDetailCommand command)
        {
            var result = await _repository.GetByIdAsync(command.OrderDetailId);
            result.OrderDetailId = command.OrderDetailId;
                    result.ProductName = command.ProductName;
                    result.ProductId = command.ProductId;
                    result.ProductPrice = command.ProductPrice;
                    result.ProductAmount = command.ProductAmount;
                    result.ProductTotalPrice = command.ProductTotalPrice;
                    result.OrderingId = command.OrderingId;
        }
    }
}
