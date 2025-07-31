using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure;

public class DbInitializer
{
    public static async Task SeedRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        string[] roles = ["Admin", "Claimant", "Adjuster", "Approver"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        var admin = new ApplicationUser
        {
            UserName = "admin@eclaim.com",
            Email = "admin@eclaim.com",
            FullName = "Super Admin",
            EmailConfirmed = true
        };

        if (await userManager.FindByEmailAsync(admin.Email) == null)
        {
            var result = await userManager.CreateAsync(admin, "Admin@123");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(admin, "Admin");
        }
    }

}
