using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Todo.Dal;
using Todo.Mvc.Extensions;

namespace Todo.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .ApplyPendingMigrations<TodoDbContext>()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
