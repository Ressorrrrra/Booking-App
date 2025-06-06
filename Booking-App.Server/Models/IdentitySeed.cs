﻿using Microsoft.AspNetCore.Identity;

namespace Booking_App.Server.Models
{
    public static class IdentitySeed
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await roleManager.FindByNameAsync("hotelRepresentative") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("hotelRepresentative"));
            }

            string adminEmail = "admin@mail.com";
            string adminPassword = "Admin123!";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

            string userEmail = "user@mail.com";
            string userPassword = "User123!";
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                User user = new User { Email = userEmail, UserName = userEmail };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }

            string representativeEmail = "hotel@mail.com";
            string representativePassword = "Hotel123!";
            if (await userManager.FindByNameAsync(representativeEmail) == null)
            {
                User representative = new User { Email = representativeEmail, UserName = representativeEmail };
                IdentityResult result = await userManager.CreateAsync(representative, representativePassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(representative, "hotelRepresentative");
                }
            }
        }
    }
}
