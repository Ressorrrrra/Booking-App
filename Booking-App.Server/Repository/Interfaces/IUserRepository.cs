﻿using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;



namespace Booking_App.Server.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<IdentityResult> Register(RegistrationRequest request);
        public Task<User?> LogIn(LogInRequest request);
        public Task<bool> LogOff(ClaimsPrincipal userData);
        public Task<IList<string>> GetUserRoles(User user);

        public Task<User?> IsAuthenticated(ClaimsPrincipal userData);
    }
}
