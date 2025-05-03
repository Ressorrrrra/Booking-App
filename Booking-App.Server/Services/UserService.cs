using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Booking_App.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Booking_App.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDataDto?> IsAuthenticated(ClaimsPrincipal userData)
        {
            User user = await _userRepository.IsAuthenticated(userData);
            if (user == null)
            {
                return null;
            }

            return new UserDataDto { Id = user.Id, UserName = user.UserName, UserRole = await GetRole(user) };
        }

        private async Task<string?> GetRole(User user)
        {
            IList<string> roles = await _userRepository.GetUserRoles(user);
            return roles.FirstOrDefault();
        }

        public async Task<UserDataDto?> LogIn(LogInRequest request)
        {
            var user = await _userRepository.LogIn(request);
            if (user == null) 
            {
                return null;
            }

            return new UserDataDto { Id = user.Id, UserName = user.UserName, UserRole = await GetRole(user) };
        }

        public Task<bool> LogOff(ClaimsPrincipal userData)
        {
            return _userRepository.LogOff(userData);
        }

        public async Task<IdentityResult> Register(RegistrationRequest request)
        {
            return await _userRepository.Register(request);
        }
    }
}
