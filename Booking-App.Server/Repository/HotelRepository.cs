using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await db.Hotels.Include(hotel => hotel.Rooms).ToListAsync();
        }

        public async Task CreateHotel(Hotel hotel)
        {
            await db.Hotels.AddAsync(hotel);
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
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateHotel(Hotel hotel, int id)
        {
            var existingHotel = await db.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            if (existingHotel == null)
            {
                return false; 
            }

            existingHotel.PictureLinks = hotel.PictureLinks;
            existingHotel.City = hotel.City;
            existingHotel.Country = hotel.Country;
            existingHotel.Description = hotel.Description;
            existingHotel.Name = hotel.Name;
            existingHotel.Tags = hotel.Tags;

            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Hotel>> SearchHotels(HotelSearchRequest request)
        {
            return await db.Hotels.Include
                (hotel => hotel.Rooms)
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
                    (request.MinPrice == null || room.Price >= request.MinPrice) &&
                    (request.MaxPrice == null || room.Price <= request.MaxPrice) &&
                    // Проверка на доступность по датам (если даты заданы)
                    (!request.ArrivalDate.HasValue || !request.DepartureDate.HasValue ||
                     !room.Orders.Any(order =>
                         // Условие, что даты бронирования пересекаются с заданным диапазоном
                         order.DepartureDate <= request.ArrivalDate &&
                         order.ArrivalDate >= request.DepartureDate
                     ))
                )
            )
            .ToListAsync();
        }

        public Task<List<Hotel>> GetHotelsByCreatorId(string creatorId)
        {
            return db.Hotels.Where(hotel => hotel.CreatorId == creatorId).ToListAsync();
        }

        public async Task CloseRoom(int roomId, string userId, DateTime startDate, DateTime endDate)
        {
            var room = await db.Rooms.FirstOrDefaultAsync(room => room.Id == roomId);
            if (room == null) return;
            var time = DateTime.UtcNow;
            var closeOrder = new Order
            {
                AdultsAmount = 0,
                ChildrenAmount = 0,
                ArrivalDate = startDate,
                DepartureDate = endDate,
                OrderStatus = OrderStatus.Closed,
                TotalPrice = 0,
                RoomId = roomId,
                UserId = userId,
                OrderTime = time,
            };
            await db.Orders.AddAsync(closeOrder);

            var orders = await db.Orders.Where(order => order.RoomId == roomId && (order.ArrivalDate >= startDate && order.ArrivalDate <= endDate
                        || order.DepartureDate >= startDate && order.DepartureDate <= endDate)).ToListAsync();
            foreach (var order in orders)
            {
                order.OrderStatus = OrderStatus.Cancelled;
            }
            await db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetRoomOrders(int roomId)
        {
            var oneMonthLater = DateTime.UtcNow.AddDays(30);
            return await db.Orders.Where(order => order.RoomId == roomId && (order.OrderStatus != OrderStatus.Cancelled || order.OrderStatus != OrderStatus.Completed) && order.DepartureDate > DateTime.UtcNow && order.DepartureDate <= oneMonthLater).OrderBy(order => order.DepartureDate).ToListAsync();
        }

    }
}
