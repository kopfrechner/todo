using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Todo.Mvc.Extensions
{
    public static class HostExtensions 
    {
        public static IHost ApplyPendingMigrations<T>(this IHost host) where T: DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<T>();
                try
                {
                    var pendingMigrationsCount = context.Database.GetPendingMigrations().Count();
                    if (pendingMigrationsCount > 0)
                    {
                        logger.LogInformation($"Applying {pendingMigrationsCount} migrations ...");
                        context.Database.SetCommandTimeout(60 * 10); // 10m timeout
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Unable to apply migrations.");
                }
            }

            return host;
        }
    }
}