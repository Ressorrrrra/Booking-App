using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public HotelShortDTO Hotel { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int AdultsAmount { get; set; }
        public int ChildrenAmount { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime OrderTime { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
