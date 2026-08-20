using MultiShopOrderApplication.Features.CQRS.Queries.AdressQueries;
using MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries;
using MultiShopOrderApplication.Features.CQRS.Results.AdressResults;
using MultiShopOrderApplication.Features.CQRS.Results.OrderDetailsResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
       
            private readonly IRepository<OrderDetail> _repository;

            public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }
            public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
            {
                var result = (await _repository.GetByIdAsync(query.id));

                return new GetOrderDetailByIdQueryResult
                {
                    OrderDetailId = result.OrderDetailId,
                    ProductName = result.ProductName,
                    ProductId = result.ProductId,
                    ProductPrice = result.ProductPrice,
                    ProductAmount = result.ProductAmount,
                    ProductTotalPrice = result.ProductTotalPrice,
                    OrderingId = result.OrderingId,

                };
            }

        }
    }
