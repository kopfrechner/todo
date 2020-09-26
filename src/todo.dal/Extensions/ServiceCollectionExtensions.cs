using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Dal.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddDbContext<T>(opts =>
            {
                var dbKey = configuration["DbConnectionString"];
                var dbConnectionString = configuration.GetConnectionString(dbKey);
                var dbDriver = configuration.GetConnectionString($"{dbKey}DbDriver");

                switch (dbDriver)
                {
                    case "Sqlite":
                        opts.UseSqlite(dbConnectionString);
                        break;
                    case "SqlServer":
                        opts.UseSqlServer(dbConnectionString);
                        break;
                }
            });
        }
    }
}