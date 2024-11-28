﻿using Booking_App.Server.Models;
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
            return await db.Orders.FindAsync(id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await db.Orders.ToListAsync();
        }

        public async Task CreateOrder(Order Order)
        {
            await db.Orders.AddAsync(Order);
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
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
            await SaveAsync();
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

            await SaveAsync();
            return true;
        }
    }
}
