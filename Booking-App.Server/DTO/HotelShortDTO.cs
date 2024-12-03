namespace Booking_App.Server.DTO
{
    public class HotelShortDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal? MinPrice { get; set; }
        public string? Picture { get; set; }
    }
}
