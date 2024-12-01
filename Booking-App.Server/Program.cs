
using Booking_App.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace Booking_App.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        builder.WithOrigins("https://localhost:5174")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.CreateDependencies(connectionString);




            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
