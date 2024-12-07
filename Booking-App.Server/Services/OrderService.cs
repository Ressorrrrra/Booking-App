using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Booking_App.Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public async Task<decimal?> CalculatePrice(int roomId, DateTime arrivalDate, DateTime departureDate, int childrenAmount, int adultsAmount)
        {
            var room = await _OrderRepository.GetRoomById(roomId);
            TimeSpan difference = departureDate.Subtract(arrivalDate);
            int daysBetweenDates = difference.Days;
            if (daysBetweenDates <= 0) return null;
            decimal price = (adultsAmount + childrenAmount) * room.Price * daysBetweenDates;
            return price;
        }

        public async Task<bool> CreateOrder(Order order)           
        {
            decimal? totalPrice = await CalculatePrice(order.RoomId, order.ArrivalDate, order.DepartureDate, order.ChildrenAmount, order.AdultsAmount);
            if (totalPrice == null) return false;
            order.TotalPrice = (decimal)totalPrice;
            return await _OrderRepository.CreateOrder(order);
            
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

        public async Task<List<Order>?> GetUserOrders(string userId)
        {
            return await _OrderRepository.GetUserOrders(userId);
        }

        public async Task<bool> UpdateOrder(Order order, int id)
        {
            return await _OrderRepository.UpdateOrder(order, id);
        }
    }
}
