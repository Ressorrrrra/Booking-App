using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IHotelRepository
    {
        public async Hotel? GetHotel(int id);
        public async List<Hotel>? GetHotels();
        public void CreateHotel(Hotel hotel);
    }
}
