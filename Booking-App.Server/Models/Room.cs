using System.Text.Json.Serialization;

namespace Booking_App.Server.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
