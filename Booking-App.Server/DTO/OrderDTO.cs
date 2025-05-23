﻿using Booking_App.Server.Models;

namespace Booking_App.Server.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public HotelShortDto Hotel { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int AdultsAmount { get; set; }
        public int ChildrenAmount { get; set; }
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public DateTimeOffset OrderTime { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
