using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class CreateHotelRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;

        public List<string> Tags { get; set; } = null!;
        public List<string> PictureLinks { get; set; } = null!;
    }
}
