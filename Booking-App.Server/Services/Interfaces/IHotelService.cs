using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IHotelService
    {
        public Hotel? GetHotel(int id);

        public List<Hotel>? GetHotels();
        public void CreateHotel(Hotel hotel);
    }
}
