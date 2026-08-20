using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Queries.AdressQueries
{
    public class GetAdressByIdQuery
    {
        public int id { get; set; }

        public GetAdressByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
