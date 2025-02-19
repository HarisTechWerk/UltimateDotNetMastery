using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using UltimateDotNetMastery.Core.Models;


namespace UltimateDotNetMastery.Core.SeedData
{
    public class DataSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DataSeeder(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            // Create Roles if not exists
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Admin User if not exists
            string adminEmail = "admin@domain.com";
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    FullName = "Admin User"
                };
                await _userManager.CreateAsync(adminUser, "Admin@123"); // Set secure password
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}