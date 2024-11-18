using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server.Models
{
    public class BookingContext : DbContext
    {
        public virtual DbSet<Hotel> Hotels { get; set; }

        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder
        modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
