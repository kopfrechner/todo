using Microsoft.EntityFrameworkCore;
using todo.dal.Models.Abstractions;

namespace todo.dal.Extensions
{
    public static class ModelBuilderExtensions 
    {
        public static void ConfigureEntityId<T>(this ModelBuilder modelBuilder) where T : class, IEntityWithId
        {
            modelBuilder.Entity<T>().HasKey(x => x.Id);
        }
        
        public static void ConfigureTenantRelationEntity<T>(this ModelBuilder modelBuilder, DeleteBehavior onTenantDeleteBehavior = DeleteBehavior.SetNull) where T : class, ITenantRelation
        {
            modelBuilder.Entity<T>().HasOne(x => x.Tenant).WithMany().HasForeignKey(x => x.TenantId).OnDelete(onTenantDeleteBehavior);
        }
        
        public static void ConfigureTenantEntityWithId<T>(this ModelBuilder modelBuilder, DeleteBehavior onTenantDeleteBehavior = DeleteBehavior.SetNull) where T : class, ITenantEntityWithId
        {
            modelBuilder.ConfigureEntityId<T>();
            modelBuilder.ConfigureTenantRelationEntity<T>(onTenantDeleteBehavior);
        }
    }
}