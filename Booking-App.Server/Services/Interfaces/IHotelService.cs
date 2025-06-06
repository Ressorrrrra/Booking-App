﻿using Booking_App.Server.DTO;
using Booking_App.Server.Models;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IHotelService
    {
        public Task<Hotel?> GetHotel(int id);
        public Task<List<HotelShortDto>> GetHotelsByCreatorId(string creatorId);
        public Task<List<Hotel>?> GetHotels();
        public Task<List<HotelShortDto>?> GetHotelsDTO();
        public Task<List<HotelShortDto>?> SearchHotels(HotelSearchRequest request);
        public Task<bool> DeleteHotel(int id);
        public Task<bool> UpdateHotel(CreateHotelRequest hotel, int id);
        public Task CreateHotel(CreateHotelRequest hotel, string creatorId);
        public Task CloseRoom(int roomId, string UserId, DateTime startDate, DateTime endDate);
        public Task<List<OrderDto>> GetRoomOrders(int roomId);
    }
}
