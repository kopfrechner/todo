using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Todo.Core.Extensions;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core
{
    public class TodoDbContextTenantProxy : ITodoDbContext
    {
        private readonly TodoDbContext _db;
        private Guid _tenantId;

        public TodoDbContextTenantProxy(
            IHttpContextAccessor httpContextAccessor,
            TodoDbContext db /* needs to be the concrete type here (only here), otherwise DI mess up */)
        {
            var httpContext = httpContextAccessor.HttpContext;
            
            var userIsAuthenticated = httpContext?.User?.Identity?.IsAuthenticated ?? false;
            if (!userIsAuthenticated)
            {
                throw new InvalidOperationException("User needs to be authenticated to access tenant specific db context.");
            }

            var tenantClaim = httpContext.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.GroupSid);
            if (tenantClaim == null)
            {
                throw new InvalidOperationException("Did not find tenant claim.");
            }
            
            _tenantId = Guid.Parse(tenantClaim.Value);
            _db = db;
        }

        public DbSet<Tenant> Tenants
        {
            get => _db.Tenants;
            set => _db.Tenants = value;
        }

        public DbSet<TenantUser> TenantUsers {
            get => _db.TenantUsers;
            set => _db.TenantUsers = value;
        }

        public DbSet<TodoItem> TodoItems {
            get => _db.TodoItems.OfTenant(_tenantId);
            set => _db.TodoItems = value;
        }
        
        public DbSet<TodoList> TodoLists {
            get => _db.TodoLists.OfTenant(_tenantId);
            set => _db.TodoLists = value;
        }
        

        public void BeginTransaction()
        {
            _db.BeginTransaction();
        }

        public void Commit()
        {
            _db.Commit();
        }

        public void Rollback()
        {
            _db.Rollback();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}