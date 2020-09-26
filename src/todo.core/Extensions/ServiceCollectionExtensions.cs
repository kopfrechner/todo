using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core.IdentiyCustomization;
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
            services.AddTransient<TodoDbContextTenantProxy>();
            services.AddTransient(provider =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var httpContext = httpContextAccessor.HttpContext;
                var hasTenantClaim =
                    (httpContext?.User?.Identity?.IsAuthenticated ?? false) &&
                    httpContext.User.HasClaim(c => c.Type == ClaimTypes.GroupSid);

                return hasTenantClaim
                    ? (ITodoDbContext) provider.GetRequiredService<TodoDbContextTenantProxy>()
                    : (ITodoDbContext) provider.GetRequiredService<TodoDbContext>();
            });
        }
    }
}