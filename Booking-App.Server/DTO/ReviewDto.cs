using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public int Rating { get; set; }
        public DateTimeOffset? PostDate { get; set; }
        public string Text { get; set; } = null!;
    }
}
