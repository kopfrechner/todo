using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core;
using Todo.Core.IdentiyCustomization;
using Todo.Dal.Models;

[assembly: HostingStartup(typeof(Todo.Mvc.Areas.Identity.IdentityHostingStartup))]
namespace Todo.Mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddTransient<IEmailSender, EmailSender>();
                services.AddTransient<UserWithTenantManager<User>>();
            });
        }
    }
}