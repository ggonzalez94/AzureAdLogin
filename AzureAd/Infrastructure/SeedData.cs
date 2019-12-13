using Microsoft.AspNetCore.Identity;

namespace AzureAd.Infrastructure
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            var adminUserName = "admin@test.com";
            var regularUserName = "user@test.com";
            if (userManager.FindByEmailAsync(adminUserName).Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = adminUserName;
                user.Email = adminUserName;

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync(regularUserName).Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = regularUserName;
                user.Email = regularUserName;

                IdentityResult result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
