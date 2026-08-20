using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands
{
    public class CreateAdressCommand
    {
        public String UserId { get; set; }
        public String District { get; set; }
        public String City { get; set; }
        public String Detail { get; set; }
    }
}
