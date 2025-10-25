using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Entities.Identity;

namespace MyShop.Identity;

public static class SeedRoles
{
    public static async Task Initialize(RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        string[] roleNames = { "Admin", "User", "Seller" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist) await roleManager.CreateAsync(new ApplicationRole { Name = roleName });
        }

        var adminUser = new ApplicationUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            EmailConfirmed = true,
            IsAdmin = true
        };

        var adminPassword = "Admin123!";

        var user = await userManager.FindByEmailAsync(adminUser.Email);

        if (user == null)
        {
            var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);
            if (createAdmin.Succeeded) await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}