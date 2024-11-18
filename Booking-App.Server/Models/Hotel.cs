namespace Booking_App.Server.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City {  get; set; }
        public decimal Price { get; set; }

        public List<string> Tags { get; set; }
        public List<string> PictureLinks { get; set; }
    }
}
