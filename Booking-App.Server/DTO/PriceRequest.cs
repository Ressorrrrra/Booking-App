namespace Booking_App.Server.DTO
{
    public class PriceRequest
    {
        public int RoomId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int ChildrenAmount { get; set; }
        public int AdultsAmount { get; set; }
    }
}
