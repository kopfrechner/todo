using Microsoft.Extensions.DependencyInjection;

namespace Todo.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTodoServices(this IServiceCollection services)
        {
            services.AddTransient<ITenantService, TenantService>();
            services.AddTransient<ITodoService, TodoService>();
        }
    }
}