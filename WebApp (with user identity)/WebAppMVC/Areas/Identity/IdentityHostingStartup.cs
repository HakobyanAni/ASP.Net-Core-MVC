using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppMVC.Models;

[assembly: HostingStartup(typeof(WebAppMVC.Areas.Identity.IdentityHostingStartup))]
namespace WebAppMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebAppMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebAppMVCContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<WebAppMVCContext>();
            });
        }
    }
}