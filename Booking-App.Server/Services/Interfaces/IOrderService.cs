using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDto?> GetOrder(int id);

        public Task<List<Order>?> GetOrders();
        public Task<List<OrderDto>?> GetUserOrders(string userId);
        public Task<decimal?> CalculatePrice(int roomId, DateTimeOffset arrivalDate, DateTimeOffset departureDate, int childrenAmount, int adultsAmount);
        public Task<bool> DeleteOrder(int id);
        public Task<bool> UpdateOrder(CreateOrderRequest order, int id);
        public Task CreateOrder(CreateOrderRequest order);
        public Task<bool> CancelOrder(int id);
    }
}
