namespace Booking_App.Server.DTO
{
    public class HotelRoomSearchRequest
    {
        public int? Number {  get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
