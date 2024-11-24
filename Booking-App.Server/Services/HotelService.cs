using Booking_App.Server.Models;
using Booking_App.Server.Repository;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await _hotelRepository.CreateHotel(hotel);
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
