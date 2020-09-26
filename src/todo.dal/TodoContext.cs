using Microsoft.EntityFrameworkCore;
using todo.dal.Extensions;
using todo.dal.Models;

namespace todo.dal
{
    /// <summary>
    /// Our database context for our project
    /// </summary>
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        { }

        public DbSet<Tenant> Tenants { get; set; }
        
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TotoList> TodoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");
            
            modelBuilder.ConfigureEntityId<Tenant>();
            
            modelBuilder.ConfigureTenantEntityWithId<TodoItem>();
            modelBuilder.ConfigureTenantEntityWithId<TotoList>();
        }
    }
}