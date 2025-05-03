namespace Booking_App.Server.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int Rating { get; set; }
        public DateTimeOffset PostDate { get; set; }
        public string Text { get; set; } = null!;
    }
}
