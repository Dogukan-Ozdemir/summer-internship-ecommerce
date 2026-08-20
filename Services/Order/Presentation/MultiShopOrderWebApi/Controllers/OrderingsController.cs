using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries;
using MultiShopOrderApplication.Features.Mediator.Commands.OrderingCommands;
using MultiShopOrderApplication.Features.Mediator.Queries.OrderingQueries;

namespace MultiShopOrderWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingById(string id)
        {
            // If it's an integer, return order by id
            if (int.TryParse(id, out int orderId))
            {
                var result = await _mediator.Send(new GetOrderingByIdQuery(orderId));
                return Ok(result);
            }

            // Otherwise treat it as a UserId
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> UpgdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("order updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommnad(id));
            return Ok("order removed");
        }
        [HttpGet("GetOrderingByUserId")]
        public async Task<IActionResult> GetOrderingByUserId()
        {
            var userId = User.FindFirst("sub")?.Value;

            var values = await _mediator.Send(new GetOrderingByUserIdQuery(userId));

            return Ok(values);
        }
    }
}
