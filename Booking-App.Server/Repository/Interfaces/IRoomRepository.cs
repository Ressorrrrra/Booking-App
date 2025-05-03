using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public Task<Room?> GetRoom(int id);
        public Task<List<Room>?> SearchRooms(HotelSearchRequest request);
        public Task<bool> DeleteRoom(int id);
        public Task<bool> UpdateRoom(Room room, int id);
        public Task CreateRoom(Room room);
    }
}
