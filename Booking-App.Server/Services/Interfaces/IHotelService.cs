using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IHotelService
    {
        public Task<Hotel?> GetHotel(int id);

        public Task<List<Hotel>?> GetHotels();
        public Task CreateHotel(Hotel hotel);
    }
}
