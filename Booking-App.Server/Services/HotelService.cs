using Booking_App.Server.Models;
using Booking_App.Server.Repository;
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Services
{
    public class HotelService : IHotelService
    {
        private HotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _hotelRepository.CreateHotel(hotel);
        }

        public async Task<Hotel?> GetHotel(int id)
        {
            return await _hotelRepository.GetHotel(id);
        }

        public async Task<List<Hotel>?> GetHotels()
        {
            return await _hotelRepository.GetHotels();
        }
    }
}
