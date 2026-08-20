using MediatR;
using MultiShopOrderApplication.Features.Mediator.Results.OrderingResults;

namespace MultiShopOrderApplication.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public GetOrderingByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}