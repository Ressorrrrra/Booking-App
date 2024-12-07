using Booking_App.Server.Controllers;
using Booking_App.Server.Models;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_app.Tests
{
    public class OrderTests
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly OrdersController _controller;

        public OrderTests()
        {
            _mockOrderService = new Mock<IOrderService>();
            _controller = new OrdersController(_mockOrderService.Object);
        }

        [Fact]
        public async Task Get_AllOrders()
        {
            // Arrange
            var mockOrders = new List<Order>
            {
                new Order { Id = 1, RoomId = 1 },
                new Order { Id = 2, RoomId = 2 }
            };

            _mockOrderService.Setup(service => service.GetOrders())
                             .ReturnsAsync(mockOrders);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var orders = Assert.IsAssignableFrom<IEnumerable<Order>>(okResult.Value);

            Assert.NotNull(orders);
            Assert.Equal(2, orders.Count());
        }

        [Fact]
        public async Task GetOrderById_Success()
        {
            // Arrange
            int testId = 1;
            var mockOrder = new Order { Id = testId, RoomId = 1 };

            _mockOrderService.Setup(service => service.GetOrder(testId))
                             .ReturnsAsync(mockOrder);

            // Act
            var result = await _controller.GetOrderById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var order = Assert.IsAssignableFrom<Order>(okResult.Value);

            Assert.NotNull(order);
            Assert.Equal(testId, order.Id);
        }

        [Fact]
        public async Task GetOrderById_NotFound()
        {
            // Arrange
            int nonExistingId = 999;

            _mockOrderService.Setup(service => service.GetOrder(nonExistingId))
                             .ReturnsAsync(() => null);

            // Act
            var result = await _controller.GetOrderById(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostOrder_Success()
        {
            // Arrange
            var newOrder = new Order { RoomId = 54 };

            _mockOrderService.Setup(service => service.CreateOrder(newOrder));

            // Act
            var result = await _controller.PostOrder(newOrder);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result.Result);

            Assert.NotNull(createdResult);
        }

        [Fact]
        public async Task UpdateOrder_Success()
        {
            // Arrange
            int existingId = 1;
            var updatedOrder = new Order { Id = existingId, RoomId = 1 };

            _mockOrderService.Setup(service => service.UpdateOrder(updatedOrder, existingId))
                             .ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateOrder(existingId, updatedOrder);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult);
        }

        [Fact]
        public async Task UpdateOrder_NotFound()
        {
            // Arrange
            int nonExistingId = 999;
            var updatedOrder = new Order { Id = nonExistingId, RoomId = 1 };

            _mockOrderService.Setup(service => service.UpdateOrder(updatedOrder, nonExistingId))
                             .ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateOrder(nonExistingId, updatedOrder);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task DeleteOrder_Success()
        {
            // Arrange
            int existingId = 5;

            _mockOrderService.Setup(service => service.DeleteOrder(existingId))
                             .ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteOrder(existingId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteOrder_NotFound()
        {
            // Arrange
            int nonExistingId = 999;

            _mockOrderService.Setup(service => service.DeleteOrder(nonExistingId))
                             .ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteOrder(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

    }
}
