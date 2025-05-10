namespace Booking_App.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RoomId {  get; set; }
        public Room Room { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public int AdultsAmount {  get; set; }
        public int ChildrenAmount { get; set; }
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set;}
        public DateTimeOffset OrderTime { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
