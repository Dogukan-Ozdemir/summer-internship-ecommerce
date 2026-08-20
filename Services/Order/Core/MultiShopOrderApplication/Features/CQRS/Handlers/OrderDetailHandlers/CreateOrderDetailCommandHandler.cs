using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _Repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _Repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _Repository.CreateAsync(new OrderDetail
            {
                
                ProductName = command.ProductName,
                ProductId = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId,
            });



        }




    }
}
