using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly BookingContext db;

        public HotelRepository(BookingContext bookingContext)
        {
            db = bookingContext;
        }

        public async Task<Hotel?> GetHotel(int id)
        {
            return await db.Hotels.FindAsync(id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await db.Hotels.ToListAsync();
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await db.Hotels.AddAsync(hotel);
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

    }
}
