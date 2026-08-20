using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers
{
    public class RemoveAdressCommandHandler
    {
        private readonly IRepository<Adress> _Repository;

        public RemoveAdressCommandHandler(IRepository<Adress> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveAdressComnad removeCommnad)
        {
            var result = (await _Repository.GetByIdAsync(removeCommnad.id));
            await _Repository.DeleteAsync(result);
        }



    }
}
