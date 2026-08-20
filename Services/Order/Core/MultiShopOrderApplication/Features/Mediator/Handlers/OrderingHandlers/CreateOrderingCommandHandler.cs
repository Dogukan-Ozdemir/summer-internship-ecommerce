using MediatR;
using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand , int>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }


        public async Task<int> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = new Ordering
            {
                OrderDate = request.OrderDate,
                UserId = request.UserId,
                TotalPrice = request.TotalPrice,
            };

            await _repository.CreateAsync(ordering);

            return ordering.OrderingId;
        }
    }
}
