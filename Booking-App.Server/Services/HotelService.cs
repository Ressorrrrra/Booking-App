using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;

namespace Booking_App.Server.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task CloseRoom(int roomId, string UserId, DateTime startDate, DateTime endDate)
        {
            await _hotelRepository.CloseRoom(roomId, UserId, startDate, endDate);    
        }

        public async Task CreateHotel(CreateHotelRequest request, string creatorId)
        {
            var hotel = new Hotel
            {
                City = request.City,
                CreatorId = creatorId,
                Country = request.Country,
                Name = request.Name,
                Description = request.Description,
                PictureLinks = request.PictureLinks,
                Tags = request.Tags,
            };
            await _hotelRepository.CreateHotel(hotel);
        }

        public async Task<bool> DeleteHotel(int id)
        {
            return await _hotelRepository.DeleteHotel(id);
        }

        public async Task<Hotel?> GetHotel(int id)
        {
            return await _hotelRepository.GetHotel(id);
        }

        public async Task<List<Hotel>?> GetHotels()
        {
            return await _hotelRepository.GetHotels();
        }

        public async Task<List<HotelShortDto>> GetHotelsByCreatorId(string creatorId)
        {
            return (await _hotelRepository.GetHotelsByCreatorId(creatorId)).Select(hotel => new HotelShortDto
            {
                City = hotel.City,
                Country = hotel.Country,
                Name = hotel.Name,
                Id = hotel.Id,
                Picture = hotel.PictureLinks[0]
            }).ToList();
        }

        public async Task<List<HotelShortDto>?> GetHotelsDTO()
        {
            var hotels = await _hotelRepository.GetHotels();

            if (hotels == null)
                return null;

            var hotelDtos = hotels
                .Select(hotel => new HotelShortDto
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Country = hotel.Country,
                    City = hotel.City,
                    Picture = hotel.PictureLinks[0],
                    MinPrice = hotel.Rooms != null && hotel.Rooms.Any()
                        ? hotel.Rooms.Min(room => room.Price) // Находим минимальную цену
                        : null // Если номеров нет, выводим "N/A"

                })
                .ToList();

            return hotelDtos;
        }

        public async Task<List<OrderDto>> GetRoomOrders(int roomId)
        {
            return (await _hotelRepository.GetRoomOrders(roomId)).Select(order => new OrderDto
            {
                Id = order.Id,
                AdultsAmount = order.AdultsAmount,
                ChildrenAmount = order.ChildrenAmount,
                ArrivalDate = order.ArrivalDate,
                DepartureDate = order.DepartureDate,
                OrderStatus = order.OrderStatus,
                OrderTime = order.OrderTime,
                RoomId = order.RoomId,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
            }).ToList();
        }

        public async Task<List<HotelShortDto>?> SearchHotels(HotelSearchRequest request)
        {
            var hotels = await _hotelRepository.SearchHotels(request);

            if (hotels == null)
                return null;

            var hotelDtos = hotels
                .Select(hotel => new HotelShortDto
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Country = hotel.Country,
                    City = hotel.City,
                    Picture = hotel.PictureLinks[0],
                    MinPrice = hotel.Rooms != null && hotel.Rooms.Any()
                        ? hotel.Rooms.Min(room => room.Price) // Находим минимальную цену
                        : null // Если номеров нет, выводим "N/A"

                })
                .ToList();

            return hotelDtos;
        }

        public async Task<bool> UpdateHotel(CreateHotelRequest request, int id)
        {
            var hotel = new Hotel
            {
                City = request.City,
                Country = request.Country,
                Name = request.Name,
                Description = request.Description,
                PictureLinks = request.PictureLinks,
                Tags = request.Tags,
            };
            return await _hotelRepository.UpdateHotel(hotel, id);
        }
    }
}
