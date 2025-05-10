using Microsoft.AspNetCore.Identity;

namespace Booking_App.Server.Models
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
