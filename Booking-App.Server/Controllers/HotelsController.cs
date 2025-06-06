﻿using System;
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
using Booking_App.Server.DTO;

namespace Booking_App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IRoomService _roomService;
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;

        public HotelsController(IHotelService hotelService, IRoomService roomService, IReviewService reviewService, IUserService userService)
        {
            _hotelService = hotelService;
            _roomService = roomService;
            _reviewService = reviewService;
            _userService = userService; 
        }

        // GET: Hotels
        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> Get()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }

        [HttpGet("GetHotelsDTO")]
        public async Task<ActionResult<List<HotelShortDto>>> GetDto()
        {
            var hotels = await _hotelService.GetHotelsDTO();
            return Ok(hotels);
        }
        // GET: api/Hotels/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            if (hotel == null) return NotFound();
            else return Ok(hotel);
        }

        // GET: Hotels
        [HttpGet("GetHotelsByCreatorId")]
        public async Task<ActionResult<List<HotelShortDto>>> GetHotelsByCreatorId()
        {
            var user = await _userService.IsAuthenticated(HttpContext.User);
            if (user != null)
            {
                var hotels = await _hotelService.GetHotelsByCreatorId(user.UserId);
                return Ok(hotels);
            }
            else
            {
                return NotFound();
            }
        }   

        [HttpGet("{hotelId}/Reviews")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewsByHotelId(int hotelId)
        {
            var reviews = await _reviewService.GetReviewsByHotelId(hotelId);
            return Ok(reviews);
        }

        [HttpPost("{hotelId}/GetAvailableRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetAvailableRooms(RoomSearchRequest request, int hotelId)
        {
            var rooms = await _roomService.SearchRooms(request, hotelId);
            return Ok(rooms);
        }

        [HttpPost("{hotelId}/SearchRooms")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> SearchRooms(HotelRoomSearchRequest request, int hotelId)
        {
            var rooms = await _roomService.SearchHotelRooms(request, hotelId);
            return Ok(rooms);
        }

        [HttpGet("{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult<RoomDto>> GetRoomById(int roomId)
        {
            var room = await _roomService.GetRoom(roomId);
            if (room == null) return NotFound();
            else return Ok(room);
        }

        [HttpPost("{hotelId}/Rooms")]
        public async Task<IActionResult> PostRoom(CreateRoomRequest request, int hotelId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _roomService.CreateRoom(request, hotelId);
            return Created();
        }

        [HttpPut("{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> UpdateRoom(CreateRoomRequest request, int hotelId,int roomId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _roomService.UpdateRoom(request, hotelId, roomId);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            bool result = await _roomService.DeleteRoom(roomId);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.IsAuthenticated(HttpContext.User);

            if (user == null || !user.UserRole.Contains("hotelRepresentative")) return Unauthorized();
            else await _hotelService.CreateHotel(request, user.UserId);
            return Created();
        }
        
        [HttpPost("SearchHotels")]
        public async Task<ActionResult<List<HotelShortDto>>> SearchHotels([FromBody] HotelSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotels = await _hotelService.SearchHotels(request);

            if (hotels == null) return NotFound();
            else return Ok(hotels);
        }

        [HttpGet("{hotelId}/Rooms/{roomId}/GetRoomOrders")]
        public async Task<ActionResult<List<OrderDto>>> GetRoomOrders(int hotelId, int roomId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotels = await _hotelService.GetRoomOrders(roomId);

            if (hotels == null) return NotFound();
            else return Ok(hotels);
        }

        [HttpPost("{hotelId}/Rooms/{roomId}/CloseRoom")]
        public async Task<ActionResult<List<OrderDto>>> CloseRoom(int hotelId, int roomId, CloseRoomRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.IsAuthenticated(HttpContext.User);
            if (user == null)
                return Unauthorized();
            await _hotelService.CloseRoom(roomId, user.UserId, request.StartTime, request.EndTime);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            bool result = await _hotelService.DeleteHotel(id);
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
        public async Task<IActionResult> UpdateHotel(int id, CreateHotelRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _hotelService.UpdateHotel(request, id);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
