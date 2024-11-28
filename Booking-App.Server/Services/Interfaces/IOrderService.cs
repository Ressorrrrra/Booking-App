using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order?> GetOrder(int id);

        public Task<List<Order>?> GetOrders();
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(Order order, int id);
        public Task CreateOrder(Order order);
    }
}
