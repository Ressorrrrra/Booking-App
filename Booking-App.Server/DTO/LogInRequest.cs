namespace Booking_App.Server.DTO
{
    public class LogInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
