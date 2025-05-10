using Booking_App.Server.Models;
using Booking_App.Server.DTO;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
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

        [HttpGet("CancelOrder_{id}")]
        public async Task<ActionResult> CancelOrder(int id)
        {
            var result = await _orderService.CancelOrder(id);
            if (!result) return NotFound();
            else return Ok();
        }

        //[Authorize(Roles ="user")]
        [HttpGet("GetUserOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders()
        {
            var user = await _userService.IsAuthenticated(HttpContext.User);
            var orders = await _orderService.GetUserOrders(user.UserId);
            return Ok(orders);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userService.IsAuthenticated(HttpContext.User);
                order.UserId = user.UserId;
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
        public async Task<IActionResult> UpdateOrder(int id, CreateOrderRequest order)
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
