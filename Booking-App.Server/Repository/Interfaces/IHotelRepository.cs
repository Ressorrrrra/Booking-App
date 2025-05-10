using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IHotelRepository
    {
        public Task<Hotel?> GetHotel(int id);
        public Task<List<Hotel>> GetHotelsByCreatorId();
        public Task<List<Hotel>?> SearchHotels(HotelSearchRequest request);
        public Task<List<Hotel>?> GetHotels();
        public Task<bool> DeleteHotel(int id);
        public Task<bool> UpdateHotel(Hotel hotel, int id);
        public Task CreateHotel(Hotel hotel);
    }
}
