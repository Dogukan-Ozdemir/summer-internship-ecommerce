using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers
{
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public CreateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAdressCommand createAdressCommand)
        {
            await _repository.CreateAsync(new Adress
            {
                City = createAdressCommand.City,
                Detail = createAdressCommand.Detail,
                District = createAdressCommand.District,
                UserId = createAdressCommand.UserId,
            });


        }
    }
}
