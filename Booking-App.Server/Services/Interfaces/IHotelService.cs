using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IHotelService
    {
        public Task<Hotel?> GetHotel(int id);

        public Task<List<Hotel>?> GetHotels();
        public Task<List<HotelShortDTO>?> SearchHotels(HotelSearchRequest request);
        public Task<bool> DeleteHotel(int id);
        public Task<bool> UpdateHotel(Hotel hotel, int id);
        public Task CreateHotel(Hotel hotel);
    }
}
