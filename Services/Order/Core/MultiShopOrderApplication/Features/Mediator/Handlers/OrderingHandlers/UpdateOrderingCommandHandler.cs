using MediatR;
using MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;

namespace MultiShopOrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand, Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.OrderingId);

            result.OrderDate = request.OrderDate;
            result.OrderDetails = request.OrderDetails;
            result.OrderingId = request.OrderingId;
            result.TotalPrice = request.TotalPrice;
            result.UserId = request.UserId;

            await _repository.UpdateAsync(result);

            return Unit.Value;
        }
    }
}