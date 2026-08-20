using MediatR;
using MultiShopOrderApplication.Features.Mediator.Queries.OrderingQueries;
using MultiShopOrderApplication.Features.Mediator.Results.OrderingResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;

namespace MultiShopOrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByUserIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(
     GetOrderingByUserIdQuery request,
     CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values
                .Where(x => x.UserId == request.UserId)
                .Select(x => new GetOrderingByUserIdQueryResult
                {
                    OrderingId = x.OrderingId,
                    UserId = x.UserId,
                    TotalPrice = x.TotalPrice,
                    OrderDate = x.OrderDate
                })
                .ToList();
        }
    }
}