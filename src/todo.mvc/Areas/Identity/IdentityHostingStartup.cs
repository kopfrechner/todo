using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core;
using Todo.Dal.Models;

[assembly: HostingStartup(typeof(todo.mvc.Areas.Identity.IdentityHostingStartup))]
namespace todo.mvc.Areas.Identity
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