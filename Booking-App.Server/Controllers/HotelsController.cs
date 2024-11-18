using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking_App.Server.Models;
using Microsoft.AspNetCore.Cors;
using Booking_App.Server.Services;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelsController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: Hotel
        [HttpGet("GetHotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }

        [HttpPost("PostHotel")]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hotelService.CreateHotel(hotel);
            return Created();
        }
    }
}
