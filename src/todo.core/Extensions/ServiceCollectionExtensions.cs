using Microsoft.Extensions.DependencyInjection;
using Todo.Core.Tenant;
using Todo.Dal;

namespace Todo.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTodoServices(this IServiceCollection services)
        {
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddTransient<ITodoDbContext, TodoDbContext>();
        }
    }
}