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

        public async Task<decimal?> CalculatePrice(int roomId, DateTimeOffset arrivalDate, DateTimeOffset departureDate, int childrenAmount, int adultsAmount)
        {
            var room = await _OrderRepository.GetRoomById(roomId);
            if (room == null) return null;
            TimeSpan difference = departureDate.Subtract(arrivalDate);
            int daysBetweenDates = difference.Days;
            if (daysBetweenDates <= 0) return null;
            decimal price = (adultsAmount + childrenAmount) * room.Price * daysBetweenDates;
            return price;
        }

        public async Task<bool> CancelOrder(int id)
        {
            return await _OrderRepository.CancelOrder(id);
        }

        public async Task CreateOrder(CreateOrderRequest _order)           
        {
            decimal? totalPrice = await CalculatePrice(_order.RoomId, _order.ArrivalDate, _order.DepartureDate, _order.ChildrenAmount, _order.AdultsAmount);
            if (totalPrice == null) return;
            var order = new Order
            {
                AdultsAmount = _order.AdultsAmount,
                ChildrenAmount = _order.ChildrenAmount,
                ArrivalDate = _order.ArrivalDate,
                DepartureDate = _order.DepartureDate,
                RoomId = _order.RoomId,
                UserId = _order.UserId,
                OrderStatus = OrderStatus.Paid,
                OrderTime = DateTimeOffset.UtcNow,
                TotalPrice = (decimal)totalPrice,
            };
            await _OrderRepository.CreateOrder(order);
            
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await _OrderRepository.DeleteOrder(id);
        }

        public async Task<OrderDto?> GetOrder(int id)
        {
            var order = await _OrderRepository.GetOrder(id);
            if (order == null) return null;

            var orderDto = new OrderDto
            {
                Hotel = new HotelShortDto
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
                OrderStatus = order.OrderStatus,
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

        public async Task<List<OrderDto>?> GetUserOrders(string userId)
        {
            var orders = await _OrderRepository.GetUserOrders(userId);

            var orderDtos = orders?
                .Select(
                order => new OrderDto
                {
                    Hotel = new HotelShortDto
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
                    OrderStatus = order.OrderStatus,
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

        public async Task<bool> UpdateOrder(CreateOrderRequest request, int id)
        {
            decimal? totalPrice = await CalculatePrice(request.RoomId, request.ArrivalDate, request.DepartureDate, request.ChildrenAmount, request.AdultsAmount);
            if (totalPrice == null) return false;
            var order = new Order
            {
                AdultsAmount = request.AdultsAmount,
                ChildrenAmount = request.ChildrenAmount,
                ArrivalDate = request.ArrivalDate,
                DepartureDate = request.DepartureDate,
                RoomId = request.RoomId,
                UserId = request.UserId,
                OrderStatus = request.Status ?? OrderStatus.Paid,
                TotalPrice = (decimal)totalPrice,
            };
            return await _OrderRepository.UpdateOrder(order, id);
        }
    }
}
