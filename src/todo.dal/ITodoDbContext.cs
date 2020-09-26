using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Dal.Models;

namespace Todo.Dal
{
    public interface ITodoDbContext
    {
        DbSet<Tenant> Tenants { get; set; }
        DbSet<TenantUser> TenantUsers { get; set; }
        
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TodoList> TodoLists { get; set; }
        
        void BeginTransaction();
        void Commit();
        void Rollback();

        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}