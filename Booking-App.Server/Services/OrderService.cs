using Booking_App.Server.DTO;
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
            if (room == null) return null;
            TimeSpan difference = departureDate.Subtract(arrivalDate);
            int daysBetweenDates = difference.Days;
            if (daysBetweenDates <= 0) return null;
            decimal price = (adultsAmount + childrenAmount) * room.Price * daysBetweenDates;
            return price;
        }

        public async Task<bool> PayForOrder(int id)
        {
            return await _OrderRepository.PayForOrder(id);
        }

        public async Task CreateOrder(Order order)           
        {
            decimal? totalPrice = await CalculatePrice(order.RoomId, order.ArrivalDate, order.DepartureDate, order.ChildrenAmount, order.AdultsAmount);
            if (totalPrice == null) return;
            order.TotalPrice = (decimal)totalPrice;
            order.OrderTime = DateTime.Now.ToUniversalTime();
            await _OrderRepository.CreateOrder(order);
            
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _OrderRepository.DeleteOrder(id);
        }

        public async Task<OrderDTO?> GetOrder(int id)
        {
            var order = await _OrderRepository.GetOrder(id);
            if (order == null) return null;

            var orderDto = new OrderDTO
            {
                Hotel = new HotelShortDTO
                {
                    Id = order.Room.Hotel.Id,
                    Name = order.Room.Hotel.Name,
                    Country = order.Room.Hotel.Country,
                    City = order.Room.Hotel.City,
                    Picture = order.Room.Hotel.PictureLinks[0],
                },
                Id = order.Id,
                RoomId = order.RoomId,
                UserId = order.UserId,
                PaymentStatus = order.PaymentStatus,
                AdultsAmount = order.AdultsAmount,
                ChildrenAmount = order.ChildrenAmount,
                ArrivalDate = order.ArrivalDate,
                DepartureDate = order.DepartureDate,
                OrderTime = order.OrderTime,
                TotalPrice = order.TotalPrice,
            };

            return orderDto;
        }

        public async Task<List<Order>?> GetOrders()
        {
            return await _OrderRepository.GetOrders();
        }

        public async Task<List<OrderDTO>?> GetUserOrders(string userId)
        {
            var orders = await _OrderRepository.GetUserOrders(userId);

            var orderDtos = orders
                .Select(
                order => new OrderDTO
                {
                    Hotel = new HotelShortDTO
                    {
                        Id = order.Room.Hotel.Id,
                        Name = order.Room.Hotel.Name,
                        Country = order.Room.Hotel.Country,
                        City = order.Room.Hotel.City,
                        Picture = order.Room.Hotel.PictureLinks[0],
                    },
                    Id = order.Id,
                    RoomId = order.RoomId,
                    UserId = order.UserId,
                    PaymentStatus = order.PaymentStatus,
                    AdultsAmount = order.AdultsAmount,
                    ChildrenAmount = order.ChildrenAmount,
                    ArrivalDate = order.ArrivalDate,
                    DepartureDate = order.DepartureDate,
                    OrderTime = order.OrderTime,
                    TotalPrice = order.TotalPrice,
                })
                .ToList();

            return orderDtos;
        }

        public async Task<bool> UpdateOrder(Order order, int id)
        {
            return await _OrderRepository.UpdateOrder(order, id);
        }
    }
}
