using MediatR;
using MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries;
using MultiShopOrderApplication.Features.CQRS.Results.OrderDetailsResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByOrderingIdQueryHandler
    : IRequestHandler<GetOrderDetailByOrderingIdQuery, List<GetOrderDetailByOrderingIdQueryResult>>
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByOrderingIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailByOrderingIdQueryResult>> Handle(
            GetOrderDetailByOrderingIdQuery request,
            CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values
                .Where(x => x.OrderingId == request.OrderingId)
                .Select(x => new GetOrderDetailByOrderingIdQueryResult
                {
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductPrice,
                    ProductAmount = x.ProductAmount,
                    ProductTotalPrice = x.ProductTotalPrice
                })
                .ToList();

        }
    }

}
  
