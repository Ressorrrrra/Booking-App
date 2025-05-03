namespace Booking_App.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RoomId {  get; set; }
        public Room? Room { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public int AdultsAmount {  get; set; }
        public int ChildrenAmount { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set;}
        public DateTime OrderTime { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
