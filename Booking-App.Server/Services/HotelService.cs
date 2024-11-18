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

        public void CreateHotel(Hotel hotel)
        {
            _hotelRepository.CreateHotel(hotel);
        }

        public Hotel? GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }

        public List<Hotel>? GetHotels()
        {
            return _hotelRepository.GetHotels();
        }
    }
}
