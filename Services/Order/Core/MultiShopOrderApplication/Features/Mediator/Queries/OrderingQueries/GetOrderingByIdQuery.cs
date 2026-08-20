using MediatR;
using MultiShopOrderApplication.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdResult>
    {
        public int id { get; set; }

        public GetOrderingByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
