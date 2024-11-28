using Booking_App.Server.DTO;
using Booking_App.Server.Models;
using Booking_App.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Booking_App.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<User?> IsAuthenticated(ClaimsPrincipal userData)
        {
            return await _userManager.GetUserAsync(userData);
        }

        public async Task<User?> LogIn(LogInRequest request)
        {
            var result =
                    await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);
            if (result.Succeeded)
            {
                return await _userManager.FindByEmailAsync(request.Email);

            }

            return null;

        }



        public async Task<bool> LogOff(ClaimsPrincipal userData)
        {
            User user = await _userManager.GetUserAsync(userData);
            if (user == null)
            {
                return false;
            }
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<IdentityResult> Register(RegistrationRequest request)
        {
            User user = new() { Email = request.Email, UserName = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, false);
                    //Ok(new { message = "Добавлен новый пользователь: " + user.UserName });
            }
            return result;
        }
    }
}
