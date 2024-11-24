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
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }
        // GET: api/Hotels/2
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            return Ok(hotel);
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
