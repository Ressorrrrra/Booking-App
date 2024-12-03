namespace Booking_App.Server.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RoomId {  get; set; }
        public Room? Room { get; set; }
        public string UserId {  get; set; }
        public User? User { get; set; }
        public decimal TotalPrice { get; set; }
        public int AdultResidentAmount {  get; set; }
        public int ChildrenAmount { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set;}
        public DateTime OrderTime { get; set; }
        public int OrderStatus { get; set; }


    }
}
