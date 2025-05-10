using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class CreateRoomRequest
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
    }
}
