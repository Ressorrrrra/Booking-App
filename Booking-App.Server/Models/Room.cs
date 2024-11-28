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

        [JsonIgnore]
        public Hotel? Hotel { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
