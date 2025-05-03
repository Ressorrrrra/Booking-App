using Booking_App.Server.Models;
using Booking_App.Server.Repository;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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
                .AddScoped<IHotelService, HotelService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<IReviewRepository, ReviewRepository>()
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BookingContext>();
                

            return services;
        }
    }
}
