using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Results.AdressResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAdressQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GetAdressQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAdressQueryResult>> Handle() {
            var result = await _repository.GetAllAsync();
            return result.Select(x => new GetAdressQueryResult { 
                AdressId = x.AdressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
            }).ToList();
        
        }

    }
}
