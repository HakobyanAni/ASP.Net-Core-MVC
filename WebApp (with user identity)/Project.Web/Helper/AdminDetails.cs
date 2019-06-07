using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL;
using Project.DAL.Entities;
using Project.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Helper
{
    public static class AdminDetails
    {
        public static async Task SeedAsync(IServiceProvider service, ProjectDbContext context)
        {
            context.Database.Migrate();
            RoleManager<IdentityRole<int>> roleManager = service.GetRequiredService<RoleManager<IdentityRole<int>>>();

            IdentityRole<int> userRole;
            foreach (RoleEnum item in Enum.GetValues(typeof(RoleEnum)))
            {
                userRole = await roleManager.FindByNameAsync(item.ToString());

                if (userRole == null)
                {
                    await roleManager.CreateAsync(new IdentityRole<int>() { Name = item.ToString() });
                }
            }

            UserManager<UserEntity> userManager = service.GetRequiredService<UserManager<UserEntity>>();

            UserEntity admin = await userManager.FindByEmailAsync("admin@pr.com");

            if (admin == null)
            {
                admin = new UserEntity()
                {
                    Name = "Admin",
                    UserName = "admin@pr.com",
                    Email = "admin@pr.com",
                    CreateDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Deleted = false,
                    PhoneNumber = "+37477558877",
                };

                IdentityResult result = await userManager.CreateAsync(admin, "Admin@PR875");
                await userManager.AddToRoleAsync(admin, RoleEnum.Admin.ToString());
                context.SaveChanges();
            }
        }
    }
}
