using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;

namespace Ordering.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetOrdersByEmail")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByEmail(string email)
        {
            var query = new GetOrderListQuery(email);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sucessfully Updated!");    
        }

        [HttpPost("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var command = new DeleteOrderCommand(orderId);
            await _mediator.Send(command);
            return Ok("Successfully Deleted!");
        }
    }
}
