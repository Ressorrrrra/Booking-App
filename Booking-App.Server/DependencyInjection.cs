using Booking_App.Server.Models;
using Booking_App.Server.Repository;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Booking_App.Server
{
    public static class DependencyInjection
    {
        public static IServiceCollection CreateDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookingContext>(options =>
        options.UseNpgsql(connectionString));

            services
                .AddScoped<IHotelRepository, HotelRepository>()
                .AddScoped<IHotelService, HotelService>();

            return services;
        }
    }
}
