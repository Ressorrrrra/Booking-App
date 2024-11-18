using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IHotelRepository
    {
        public Task<Hotel?> GetHotel(int id);
        public Task<List<Hotel>?> GetHotels();
        public Task CreateHotel(Hotel hotel);
    }
}
