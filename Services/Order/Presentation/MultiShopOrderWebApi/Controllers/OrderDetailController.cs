using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShopOrderApplication.Features.CQRS.Commands.AdressCommands;
using MultiShopOrderApplication.Features.CQRS.Commands.OrderDetailCommannds;
using MultiShopOrderApplication.Features.CQRS.Handlers.AdressHandlers;
using MultiShopOrderApplication.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopOrderApplication.Features.CQRS.Queries.AdressQueries;
using MultiShopOrderApplication.Features.CQRS.Queries.OrderDetailQueries;
using MultiShopOrderApplication.Features.CQRS.Results.OrderDetailsResults;

namespace MultiShopOrderWebApi.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailsCommandHandler;
        private readonly GetOrderDetailByOrderingIdQueryHandler _getOrderDetailByOrderingIdQueryHandler;

        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailsCommandHandler, GetOrderDetailByOrderingIdQueryHandler getOrderDetailByOrderingIdQueryHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _updateOrderDetailsCommandHandler = updateOrderDetailsCommandHandler;
            _getOrderDetailByOrderingIdQueryHandler = getOrderDetailByOrderingIdQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var result = await _getOrderDetailQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailById(int id)
        {
            var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("created");
        }
        [HttpPut]
        public async Task<IActionResult> UpgradeOrderDetail(UpgradeOrderDetailCommand command)
        {
            await _updateOrderDetailsCommandHandler.Handle(command);
            return Ok("upgraded");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("deleted" + id);
        }

        [HttpGet("GetOrderDetailsByOrderingId/{id}")]
        public async Task<IActionResult> GetOrderDetailsByOrderingId(int id, CancellationToken cancellationToken)
        {
            var values = await _getOrderDetailByOrderingIdQueryHandler.Handle(
                new GetOrderDetailByOrderingIdQuery(id),
                cancellationToken);

            return Ok(values);
        }


        /*
         nakacnç<ancıiNFANFFWOAN554575869smcnvmeomcac"""oodqo'!')/^637847582094892ğrunfŞSJCNAşajjjajsıdoenfjnvlr
         
         */

    }
}
