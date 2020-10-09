using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Dal.Models.Abstractions;

namespace Todo.Dal.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> OfTenant<T>(this DbSet<T> dbSet, Models.Tenant tenant) where T: class
        {
            return dbSet.OfTenant(tenant.Id);
        }
        
        public static IQueryable<T> OfTenant<T>(this DbSet<T> dbSet, Guid tenantId) where T: class
        {
            return dbSet.Where(x => ((ITenantRelation) x).TenantId == tenantId);
        }
    }
}