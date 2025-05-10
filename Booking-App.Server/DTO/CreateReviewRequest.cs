namespace Booking_App.Server.DTO
{
    public class CreateReviewRequest
    {
        public int OrderId { get; set; } 
        public int Rating { get; set; }
        public string Text { get; set; } = null!;
    }
}
