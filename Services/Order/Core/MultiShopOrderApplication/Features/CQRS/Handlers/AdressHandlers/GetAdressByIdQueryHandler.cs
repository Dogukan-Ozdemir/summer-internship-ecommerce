using MultiShopOrderApplication.Features.CQRS.Queries.AdressQueries;
using MultiShopOrderApplication.Features.CQRS.Results.AdressResults;
using MultiShopOrderApplication.Interfaces;
using MultiShopOrderDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers
{
    public class GEtAdressByIdQueryHandler
    {
        private readonly IRepository<Adress> _repository;

        public GEtAdressByIdQueryHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query )
        {
            var result = (await _repository.GetByIdAsync(query.id));

            return new GetAdressByIdQueryResult
            {
                AdressId = result.AdressId,
                District= result.District,
                City = result.City,
                Detail= result.Detail,
                UserId = result.UserId,

            };
        }
        
        }



    }


