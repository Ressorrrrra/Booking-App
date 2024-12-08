using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO?> GetOrder(int id);

        public Task<List<Order>?> GetOrders();
        public Task<List<OrderDTO>?> GetUserOrders(string userId);
        public Task<decimal?> CalculatePrice(int roomId, DateTime arrivalDate, DateTime departureDate, int childrenAmount, int adultsAmount);
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(Order order, int id);
        public Task CreateOrder(Order order);
        public Task<bool> PayForOrder(int id);
    }
}
