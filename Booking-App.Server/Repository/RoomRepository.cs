using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingContext db;

        public RoomRepository(BookingContext _db)
        {
            db = _db;
        }
        public async Task CreateRoom(Room room)
        {
            await db.Rooms.AddAsync(room);
            await db.SaveChangesAsync();
        }

        public async Task CreateRooms(List<Room> rooms)
        {
            await db.Rooms.AddRangeAsync(rooms);
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var room = await this.GetRoom(id);
            if (room != null)
            {
                db.Rooms.Remove(room);
                await db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<Room?> GetRoom(int id)
        {
            return await db.Rooms.Include(r => r.Hotel).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Room>> SearchHotelRooms(HotelRoomSearchRequest request, int hotelId)
        {
            var hotel = await db.Hotels.Include(hotel => hotel.Rooms).FirstOrDefaultAsync(hotel => hotel.Id == hotelId);
            if (hotel != null && hotel.Rooms != null && hotel.Rooms.Count > 0) 
            {
                return hotel.Rooms.Where(room => room.Number.ToString().Contains(request.Number.ToString() ?? "") &&
                    (!request.MinPrice.HasValue || room.Price >= request.MinPrice.Value) &&
                    (!request.MaxPrice.HasValue || room.Price <= request.MaxPrice.Value)).ToList();
            }
            else
            {
                return new List<Room>();
            }
        }

        public Task<List<Room>> SearchRooms(RoomSearchRequest request, int hotelId)
        {
            return db.Rooms.Include(room => room.Orders)
                .Where(room => room.HotelId == hotelId && request.AdultsAmount + request.ChildrenAmount <= room.Capacity
                && !room.Orders.Any(
                    order => 
                    (order.OrderStatus != OrderStatus.Completed || order.OrderStatus != OrderStatus.Cancelled)
                    && (request.ArrivalDate >=  order.ArrivalDate && request.ArrivalDate <= order.DepartureDate
                        || request.DepartureDate >= order.ArrivalDate && request.DepartureDate <= order.DepartureDate)
                        )
                ).ToListAsync();
        }

        public async Task<bool> UpdateRoom(Room room, int id)
        {
            var existingRoom = await db.Rooms.FirstOrDefaultAsync(room => room.Id == id);
            if (existingRoom == null)
            {
                return false;
            }

            existingRoom.Number = room.Number;
            existingRoom.Price = room.Price;
            existingRoom.Capacity = room.Capacity;

            await db.SaveChangesAsync();
            return true;
        }
    }
}
