using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppRede.Areas.Identity.Data;

[assembly: HostingStartup(typeof(WebAppRede.Areas.Identity.IdentityHostingStartup))]
namespace WebAppRede.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LogContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LogContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LogContext>();
            });
        }
    }
}