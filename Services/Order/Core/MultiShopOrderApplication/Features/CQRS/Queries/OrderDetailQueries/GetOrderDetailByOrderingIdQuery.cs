using MediatR;
using MultiShopOrderApplication.Features.CQRS.Results.OrderDetailsResults;

namespace MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByOrderingIdQuery : IRequest<List<GetOrderDetailByOrderingIdQueryResult>>
    {
        public int OrderingId { get; set; }

        public GetOrderDetailByOrderingIdQuery(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}