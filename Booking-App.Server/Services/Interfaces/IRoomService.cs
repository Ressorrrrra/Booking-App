using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<RoomDto?> GetRoom(int id);
        public Task<List<RoomDto>> SearchRooms(RoomSearchRequest request, int hotelId);
        public Task<List<RoomDto>> SearchHotelRooms(HotelRoomSearchRequest request, int hotelId);
        public Task<bool> DeleteRoom(int id);
        public Task<bool> UpdateRoom(CreateRoomRequest room, int hotelId, int roomId);
        public Task CreateRoom(CreateRoomRequest room, int hotelId);
        public Task CreateRooms(List<CreateRoomRequest> room, int hotelId);
    }
}
