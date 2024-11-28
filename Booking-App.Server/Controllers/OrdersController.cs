using Booking_App.Server.Models;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }
        // GET: api/Orders/2
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrder(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _orderService.CreateOrder(order);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            bool result = await _orderService.DeleteOrder(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _orderService.UpdateOrder(order, id);

            if (result)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
