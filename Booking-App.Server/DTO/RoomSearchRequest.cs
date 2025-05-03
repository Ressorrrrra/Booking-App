namespace Booking_App.Server.DTO
{
    public class RoomSearchRequest
    {
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public int AdultsAmount { get; set; }
        public int ChildrenAmount { get; set; }
    }
}
