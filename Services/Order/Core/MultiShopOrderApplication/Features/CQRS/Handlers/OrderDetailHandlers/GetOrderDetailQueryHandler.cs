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
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _Repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _Repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            {
                var result = await _Repository.GetAllAsync();
                return result.Select(x => new GetOrderDetailQueryResult
                {
                    OrderDetailId = x.OrderDetailId,
                    ProductName = x.ProductName,
                    ProductId = x.ProductId,
                    ProductPrice = x.ProductPrice,
                    ProductAmount = x.ProductAmount,
                    ProductTotalPrice = x.ProductTotalPrice,
                    OrderingId = x.OrderingId
                }).ToList();
            }




        }
    }
}
