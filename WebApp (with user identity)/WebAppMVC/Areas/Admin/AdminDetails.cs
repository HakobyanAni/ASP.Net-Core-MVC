using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.Enumerations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppMVC.Areas.Admin
{
    public static class AdminDetails
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider, DBContext context)
        {
            UserManager<UserEntity> userManager = serviceProvider.GetRequiredService<UserManager<UserEntity>>();
            UserEntity admin = await userManager.FindByEmailAsync("admin@stat.com");

            if (admin == null)
            {
                admin = new UserEntity()
                {
                    Name = "Admin",
                    UserName = "admin@stat.com",
                    Email = "admin@stat.com",
                    Role = RoleEnum.Admin,
                    CreateDate = DateTime.Now,
                };
                var result = await userManager.CreateAsync(admin, "587!xyz");
                context.SaveChanges();
            }
        }
    }
}
