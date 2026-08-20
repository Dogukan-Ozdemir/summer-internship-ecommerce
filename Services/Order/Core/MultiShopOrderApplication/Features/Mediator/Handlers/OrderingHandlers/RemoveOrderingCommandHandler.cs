using MediatR;
using MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;

namespace MultiShopOrderApplication.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommnad, Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveOrderingCommnad request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.id);
            await _repository.DeleteAsync(result);

            return Unit.Value;
        }
    }
}