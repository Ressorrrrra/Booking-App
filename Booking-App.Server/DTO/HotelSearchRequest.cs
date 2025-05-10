using System.Security;

namespace Booking_App.Server.DTO
{
    public class HotelSearchRequest
    {
        public string? Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Country {  get; set; }
        public string? City { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }

    }
}
