using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public async Task CreateOrder(Order order)
        {
            await _OrderRepository.CreateOrder(order);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _OrderRepository.DeleteOrder(id);
        }

        public async Task<Order?> GetOrder(int id)
        {
            return await _OrderRepository.GetOrder(id);
        }

        public async Task<List<Order>?> GetOrders()
        {
            return await _OrderRepository.GetOrders();
        }

        public async Task<bool> UpdateOrder(Order order, int id)
        {
            return await _OrderRepository.UpdateOrder(order, id);
        }
    }
}
