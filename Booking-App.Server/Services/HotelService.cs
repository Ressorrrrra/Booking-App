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

        public async Task CreateHotel(Hotel hotel)
        {
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

        public async Task<bool> UpdateHotel(Hotel hotel, int id)
        {
            return await _hotelRepository.UpdateHotel(hotel, id);
        }
    }
}
