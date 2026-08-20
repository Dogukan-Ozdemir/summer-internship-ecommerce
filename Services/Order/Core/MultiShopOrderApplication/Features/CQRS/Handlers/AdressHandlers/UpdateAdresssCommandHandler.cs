using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAdresssCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public UpdateAdresssCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdressCommand command) {
            var result =await _repository.GetByIdAsync(command.AdressId);
            result.Detail=command.Detail;
            result.AdressId = command.AdressId;
            result.District = command.District;
            result.UserId = command.UserId;
            result.City = command.City;
            await _repository.UpdateAsync(result);
        }

    }
}
