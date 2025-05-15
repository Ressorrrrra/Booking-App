using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public int? Capacity { get; set; }  
    }
}
