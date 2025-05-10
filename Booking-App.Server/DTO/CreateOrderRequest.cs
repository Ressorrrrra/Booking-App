using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class CreateOrderRequest
    {
        public int RoomId { get; set; }
        public string? UserId { get; set; }
        public int AdultsAmount { get; set; }
        public int ChildrenAmount { get; set; }
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public OrderStatus? Status { get; set; }
    }
}
