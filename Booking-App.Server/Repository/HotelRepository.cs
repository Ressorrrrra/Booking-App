using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            return await db.Hotels
                .Include(h => h.Rooms) 
                .FirstOrDefaultAsync(h => h.Id == id);
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

        public async Task<bool> DeleteHotel(int id)
        {
            var hotel = await GetHotel(id);
            if (hotel == null)
            {
                return false;
            }
            db.Hotels.Remove(hotel);
            await SaveAsync();
            return true;
        }

        public async Task<bool> UpdateHotel(Hotel hotel, int id)
        {
            var existingHotel = await db.Hotels.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (existingHotel == null)
            {
                return false; 
            }

            hotel.Id = id; 
            db.Hotels.Attach(hotel);
            db.Entry(hotel).State = EntityState.Modified;

            await SaveAsync();
            return true;
        }

        public async Task<List<Hotel>> SearchHotels(HotelSearchRequest request)
        {
            return await db.Hotels
            .Where(hotel =>
                // Фильтрация по названию отеля (если указано)
                (string.IsNullOrEmpty(request.Name) || hotel.Name.ToLower().Contains(request.Name.ToLower())) &&
                // Фильтрация по стране (если указана)
                (string.IsNullOrEmpty(request.Country) || hotel.Country.ToLower() == request.Country.ToLower()) &&
                // Фильтрация по городу (если указан)
                (string.IsNullOrEmpty(request.City) || hotel.City.ToLower() == request.City.ToLower()) &&
                // Проверка, что хотя бы один номер в отеле соответствует ценовому диапазону и доступен по датам
                hotel.Rooms.Any(room =>
                    // Фильтрация по цене
                    (request.minPrice == null || room.Price >= request.minPrice) &&
                    (request.maxPrice == null || room.Price <= request.maxPrice) &&
                    // Проверка на доступность по датам (если даты заданы)
                    (!request.ArrivalDate.HasValue || !request.DepartureDate.HasValue ||
                     !room.Orders.Any(order =>
                         // Условие, что даты бронирования пересекаются с заданным диапазоном
                         order.ArrivalDate < request.DepartureDate &&
                         order.DepartureDate > request.ArrivalDate
                     ))
                )
            )
            .ToListAsync();
        }
    }
}
