using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Results.AdressResults
{
    public class GetAdressByIdQueryResult
    {
        public int AdressId { get; set; }
        public String UserId { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String Detail { get; set; }
    }
}
