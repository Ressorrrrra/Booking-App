using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;
using System.Linq.Expressions;

namespace Booking_App.Server.Services
{
    public class RoomService : IRoomService
    {
        public IRoomRepository _roomRepository { get; set; }

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task CreateRoom(CreateRoomRequest roomDto, int hotelId)
        {
            var room = new Room
            {
                HotelId = hotelId,
                Capacity = roomDto.Capacity,
                Number = roomDto.Number,
                Price = roomDto.Price,
            };
           await _roomRepository.CreateRoom(room);
        }

        public async Task CreateRooms(List<CreateRoomRequest> roomsDto, int hotelId)
        {
            var rooms = roomsDto.Select(room => new Room
            {
                HotelId = hotelId,
                Capacity = room.Capacity,
                Number = room.Number,
                Price = room.Price,
            }).ToList();
            await _roomRepository.CreateRooms(rooms);
        }

        public async Task<bool> DeleteRoom(int id)
        {
            return await _roomRepository.DeleteRoom(id);
        }

        public async Task<RoomDto?> GetRoom(int id)
        {
            var room = await _roomRepository.GetRoom(id);
            if (room == null) return null;
            else
            {
                var roomDto = new RoomDto
                {
                    Id = room.Id,
                    Number = room.Number,
                    Price = room.Price,
                    Capacity = room.Capacity,
                };
                return roomDto;
            }
        }

        public async Task<List<RoomDto>> SearchRooms(RoomSearchRequest request, int hotelId)
        {
            var rooms = await _roomRepository.SearchRooms(request, hotelId);
            return rooms.Select(room => new RoomDto 
            { 
                Id = room.Id,
                Number = room.Number,
                Price = room.Price,
            }).ToList();
        }

        public async Task<List<RoomDto>> SearchHotelRooms(HotelRoomSearchRequest request, int hotelId)
        {
            var rooms = await _roomRepository.SearchHotelRooms(request, hotelId);
            return rooms.Select(room => new RoomDto
            {
                Id = room.Id,
                Number = room.Number,
                Price = room.Price,
            }).ToList();
        }

        public async Task<bool> UpdateRoom(CreateRoomRequest room, int hotelId, int roomId)
        {
            var _room = new Room
            {
                Capacity = room.Capacity,
                HotelId = hotelId,
                Number = room.Number,
                Price = room.Price,
            };
            return await _roomRepository.UpdateRoom(_room, roomId);
        }
    }
}
