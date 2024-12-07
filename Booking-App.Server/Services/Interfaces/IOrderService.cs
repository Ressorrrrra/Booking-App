﻿using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order?> GetOrder(int id);

        public Task<List<Order>?> GetOrders();
        public Task<List<Order>?> GetUserOrders(string userId);
        public Task<decimal?> CalculatePrice(int roomId, DateTime arrivalDate, DateTime departureDate, int childrenAmount, int adultsAmount);
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(Order order, int id);
        public Task<bool> CreateOrder(Order order);
    }
}
