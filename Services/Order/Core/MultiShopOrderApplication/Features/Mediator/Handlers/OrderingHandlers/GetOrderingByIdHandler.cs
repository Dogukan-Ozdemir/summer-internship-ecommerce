using MediatR;
using MultiShopOrderApplication.Features.Mediator.Queries.OrderingQueries;
using MultiShopOrderApplication.Features.Mediator.Results.OrderingResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdHandler(Interfaces.IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.id);
            return new GetOrderingByIdResult
            {
                OrderDate = result.OrderDate,
                OrderDetails = result.OrderDetails,
                OrderingId = result.OrderingId,
                TotalPrice = result.TotalPrice,
            };
        }
    }
}
