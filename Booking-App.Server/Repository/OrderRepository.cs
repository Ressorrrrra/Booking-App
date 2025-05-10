using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookingContext db;

        public OrderRepository(BookingContext bookingContext)
        {
            db = bookingContext;
        }
        public async Task<Order?> GetOrder(int id)
        {
            return await db.Orders.Include(o => o.Room.Hotel).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>?> GetOrders()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task CreateOrder(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await GetOrder(id);
            if (order == null)
            {
                return false;
            }
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOrder(Order order, int id)
        {
            var existingOrder = await db.Orders.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
            if (existingOrder == null)
            {
                return false;
            }

            order.Id = id;
            db.Orders.Attach(order);
            db.Entry(order).State = EntityState.Modified;

            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>?> GetUserOrders(string userId)
        {
            return await db.Orders.Where(o => o.UserId == userId).Include(o => o.Room).ThenInclude(r => r.Hotel).ToListAsync();
        }

        public async Task<Room?> GetRoomById(int roomId)
        {
            return await db.Rooms.FirstOrDefaultAsync(r  => r.Id == roomId);
        }

        public async Task<bool> CancelOrder(int id)
        {
            var order = await db.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return false;
            order.OrderStatus = OrderStatus.Cancelled;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
