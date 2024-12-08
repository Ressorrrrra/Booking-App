using Booking_App.Server.Models;

namespace Booking_App.Server.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order?> GetOrder(int id);
        public Task<List<Order>?> GetOrders();
        public Task<List<Order>?> GetUserOrders(string userId);
        public Task<Room?> GetRoomById(int roomId);
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(Order order, int id);
        public Task CreateOrder(Order order);
        public Task<bool> PayForOrder(int id);
    }
}
