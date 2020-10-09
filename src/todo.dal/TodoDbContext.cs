using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Todo.Dal.Extensions;
using Todo.Dal.Models;
using Todo.Dal.Models.Abstractions;

namespace Todo.Dal
{
    /// <summary>
    /// Our database context for our project
    /// </summary>
    public class TodoDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, ITodoDbContext
    {
        private IDbContextTransaction _transaction;
        private bool _userIsAuthenticated;
        private Guid _tenantId;
        
        public TodoDbContext(
            DbContextOptions options,
            IHttpContextAccessor httpContextAccessor) : base(options)
        {
            var httpContext = httpContextAccessor?.HttpContext;
            
            _userIsAuthenticated = httpContext?.User?.Identity?.IsAuthenticated ?? false;
            if (_userIsAuthenticated)
            {
                var tenantClaim = httpContext?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.GroupSid);
                if (tenantClaim == null)
                {
                    throw new InvalidOperationException("Did not find tenant claim although authenticated");
                }
                _tenantId = Guid.Parse(tenantClaim.Value);
            }
        }

        #region Tables

        public new IQueryable<T> Query<T>() where T : class
        {
            if (_userIsAuthenticated && IsITenantRelation<T>())
            {
                return Set<T>().OfTenant(_tenantId);
            }

            return Set<T>();
        }
    
        public DbSet<T> Manipulate<T>() where T: class
        {
            return Set<T>();
        }
        
        private static bool IsITenantRelation<T>()
        {
            return typeof(T).GetInterfaces().Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof(ITenantRelation));
        }
        
        #endregion

        #region Transaction
        
        public void BeginTransaction()
        { 
            _transaction = Database.BeginTransaction();
        }
 
        public void Commit()
        {
            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }        
        }
 
        public void Rollback()
        { 
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            
            modelBuilder.ConfigureEntityId<Tenant>();
            modelBuilder.ConfigureTenantEntityWithId<TenantUser>();
            modelBuilder.Entity<TenantUser>().HasOne(x => x.User).WithMany(x => x.AssignedTenants).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.ConfigureTenantEntityWithId<TodoItem>();
            modelBuilder.ConfigureTenantEntityWithId<TodoList>();
         
            modelBuilder.PluralizeTableNameConvention();
            
            modelBuilder.SeedDatabase(WithDefaults);
            
            base.OnModelCreating(modelBuilder);
        }

        private void WithDefaults(ModelBuilder modelBuilder)
        {
            var defaultTenantId = new Guid("68b45895-8b2c-4d83-8396-1959b59a21a6");
            modelBuilder.Entity<Tenant>().HasData(new Tenant
            {
                Id = defaultTenantId,
                Name = "Default Tenant"
            });

            // ============
            
            var todoListId1 = new Guid("81df3f6f-4bb8-4195-932e-a091c5019aad");
            modelBuilder.Entity<TodoList>().HasData(new TodoList
            {
                Id = todoListId1,
                Title = "TodoList 1",
                Description = "First example todo list", 
                TenantId = defaultTenantId
            });
            
            var todoItemId1 = new Guid("a9fad21f-0305-410f-a8a1-b9c997cbfa7d");
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                Id = todoItemId1,
                DoWhat = "Hack",
                Description = "Hack all day", 
                TodoListId = todoListId1,
                TenantId = defaultTenantId,
            });
            
            var todoItemId2 = new Guid("b75cbfd1-2509-4362-beea-c59baa895bae");
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                Id = todoItemId2,
                DoWhat = "Hack even more",
                Description = "Hack all night", 
                TodoListId = todoListId1,
                TenantId = defaultTenantId,
            });
            
            // ============
            
            var todoListId2 = new Guid("94260d4d-133f-403e-8b71-0521b87f2215");
            modelBuilder.Entity<TodoList>().HasData(new TodoList
            {
                Id = todoListId2,
                Title = "TodoList 2",
                Description = "Second example todo list", 
                TenantId = defaultTenantId
            });
            
            var todoItemId3 = new Guid("1c16ccb0-a05b-4c0c-af38-4dfbc90076a3");
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                Id = todoItemId3,
                DoWhat = "Drink coffee",
                Description = "Drink coffee all day", 
                TodoListId = todoListId2,
                TenantId = defaultTenantId,
            });
            
            var todoItemId4 = new Guid("936a6bef-b102-427c-805a-e06b172dec8c");
            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                Id = todoItemId4,
                DoWhat = "Drink even more coffee",
                Description = "Drink coffee all night", 
                TodoListId = todoListId2,
                TenantId = defaultTenantId,
            });
        }
    }
    
    public static class ModelBuilderExtensions 
    {
        public static void PluralizeTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName($"{entityType.DisplayName()}s");
            }
        }
    }
}