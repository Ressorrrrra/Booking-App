using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Booking_App.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> Register(RegistrationRequest request);
        public Task<UserDataDto?> LogIn(LogInRequest request);
        public Task<bool> LogOff(ClaimsPrincipal userData);

        public Task<UserDataDto?> IsAuthenticated(ClaimsPrincipal userData);
    }
}
