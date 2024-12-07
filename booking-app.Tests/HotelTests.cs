using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Booking_App.Server.Controllers;
using Booking_App.Server.Models;
using Booking_App.Server.Services.Interfaces;
using Booking_App.Server.DTO;

namespace booking_app.Tests
{

    public class HotelTests
    {
        private readonly Mock<IHotelService> hotelServiceMock;
        private readonly HotelsController controller;

        public HotelTests()
        {
            hotelServiceMock = new Mock<IHotelService>();
            controller = new HotelsController(hotelServiceMock.Object);
        }

        [Fact]
        public async Task Get_AllHotels()
        {
            // Arrange
            var mockHotels = new List<Hotel>
            {
                new Hotel { Id = 1, Name = "Hotel A" },
                new Hotel { Id = 2, Name = "Hotel B" }
            };

            hotelServiceMock.Setup(service => service.GetHotels())
                             .ReturnsAsync(mockHotels);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var hotels = Assert.IsAssignableFrom<IEnumerable<Hotel>>(okResult.Value);

            Assert.NotNull(hotels);
            Assert.Equal(2, hotels.Count());
        }


        [Fact]
        public async Task GetHotelById_Found()
        {
            // Arrange
            int testId = 1;
            var mockHotel = new Hotel { Id = testId, Name = "Hotel A" };

            hotelServiceMock.Setup(service => service.GetHotel(testId))
                             .ReturnsAsync(mockHotel);

            // Act
            var result = await controller.GetHotelById(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var hotel = Assert.IsAssignableFrom<Hotel>(okResult.Value);

            Assert.NotNull(hotel);
            Assert.Equal(testId, hotel.Id);
        }

        [Fact]
        public async Task GetHotelById_NotFound()
        {
            // Arrange
            int nonExistingId = -1;

            hotelServiceMock.Setup(service => service.GetHotel(nonExistingId))
                             .ReturnsAsync(() => null);

            // Act
            var result = await controller.GetHotelById(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostHotel_Success()
        {
            // Arrange
            var newHotel = new Hotel { Name = "New Hotel" };

            hotelServiceMock.Setup(service => service.CreateHotel(newHotel));

            // Act
            var result = await controller.PostHotel(newHotel);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result.Result);

            Assert.NotNull(createdResult);
        }

        [Fact]
        public async Task UpdateHotel_Success()
        {
            // Arrange
            int existingId = 1;
            var updatedHotel = new Hotel { Id = existingId, Name = "Updated Hotel" };

            hotelServiceMock.Setup(service => service.UpdateHotel(updatedHotel, existingId))
                             .ReturnsAsync(true);

            // Act
            var result = await controller.UpdateHotel(existingId, updatedHotel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task UpdateHotel_NotFound()
        {
            // Arrange
            int nonExistingId = 999;
            var updatedHotel = new Hotel { Id = nonExistingId, Name = "Non-existing Hotel" };

            hotelServiceMock.Setup(service => service.UpdateHotel(updatedHotel, nonExistingId))
                             .ReturnsAsync(false);

            // Act
            var result = await controller.UpdateHotel(nonExistingId, updatedHotel);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetDto_Success()
        {
            // Arrange
            var mockHotels = new List<HotelShortDTO>
            {
                new HotelShortDTO { Id = 1, Name = "Hotel A" },
                new HotelShortDTO { Id = 2, Name = "Hotel B" }
            };

            hotelServiceMock.Setup(service => service.GetHotelsDTO())
                             .ReturnsAsync(mockHotels);

            // Act
            var result = await controller.GetDto();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var hotels = Assert.IsAssignableFrom<IEnumerable<HotelShortDTO>>(okResult.Value);

            Assert.NotNull(hotels);
            Assert.Equal(2, hotels.Count());
        }

        [Fact]
        public async Task SearchHotels_Success()
        {
            // Arrange
            var searchRequest = new HotelSearchRequest { City = "CityA" };
            var matchingHotels = new List<HotelShortDTO>
            {
                new HotelShortDTO { Id = 3, Name = "Hotel C" },
                new HotelShortDTO { Id = 4, Name = "Hotel D" }
            };

            hotelServiceMock.Setup(service => service.SearchHotels(searchRequest))
                             .ReturnsAsync(matchingHotels);

            // Act
            var result = await controller.SearchHotels(searchRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var hotels = Assert.IsAssignableFrom<List<HotelShortDTO>>(okResult.Value);

            Assert.NotNull(hotels);
            Assert.Equal(2, hotels.Count());
        }

        [Fact]
        public async Task SearchHotels_NotFound()
        {
            // Arrange
            var emptyRequest = new HotelSearchRequest { City = "UnknownCity" };

            hotelServiceMock.Setup(service => service.SearchHotels(emptyRequest))
                             .ReturnsAsync(() => null);

            // Act
            var result = await controller.SearchHotels(emptyRequest);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteHotel_Success()
        {
            // Arrange
            int existingId = 5;

            hotelServiceMock.Setup(service => service.DeleteHotel(existingId))
                             .ReturnsAsync(true);

            // Act
            var result = await controller.DeleteHotel(existingId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteHotel_NotFound()
        {
            // Arrange
            int nonExistingId = 999;

            hotelServiceMock.Setup(service => service.DeleteHotel(nonExistingId))
                             .ReturnsAsync(false);

            // Act
            var result = await controller.DeleteHotel(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

}
