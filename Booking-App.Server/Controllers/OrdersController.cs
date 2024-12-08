using Booking_App.Server.Models;
using Booking_App.Server.DTO;
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
        [HttpGet("GetOrderById_{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (order == null) return NotFound();
            else return Ok(order);
        }

        [HttpGet("PayForOrder_{id}")]
        public async Task<ActionResult> PayForOrder(int id)
        {
            var result = await _orderService.PayForOrder(id);
            if (!result) return NotFound();
            else return Ok();
        }

        [HttpGet("GetUserOrders_{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders(string userId)
        {
            var orders = await _orderService.GetUserOrders(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _orderService.CreateOrder(order);
            }
            catch
            {
                BadRequest();
            }
            return Created();
        }

        [HttpPost("GetPrice")]
        public async Task<ActionResult<decimal>> GetPrice(PriceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal? price = await _orderService.CalculatePrice(request.RoomId, request.ArrivalDate, request.DepartureDate, request.ChildrenAmount, request.AdultsAmount);
            if (price == null) return BadRequest();
            else return Ok(price);
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
