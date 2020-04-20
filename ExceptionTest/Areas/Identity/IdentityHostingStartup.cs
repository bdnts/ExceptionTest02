using System;
using ExceptionTest.Areas.Identity.Data;
using ExceptionTest.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ExceptionTest.Areas.Identity.IdentityHostingStartup))]
namespace ExceptionTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ExceptionTestContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("ExceptionTestContextConnection")));

                services.AddDefaultIdentity<ExceptionTestUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ExceptionTestContext>();
            });
        }
    }
}