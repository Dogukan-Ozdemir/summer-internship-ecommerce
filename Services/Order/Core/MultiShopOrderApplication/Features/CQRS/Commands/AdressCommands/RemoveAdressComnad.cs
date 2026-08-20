using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands
{
    public class RemoveAdressComnad
    {
        public int id { get; set; }

        public RemoveAdressComnad(int id)
        {
            this.id = id;
        }
    }
}
