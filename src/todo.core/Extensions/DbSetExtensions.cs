using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todo.Dal.Models;
using Todo.Dal.Models.Abstractions;

namespace Todo.Core.Extensions
{
    public static class DbSetExtensions
    {
        public static DbSet<T> OfTenant<T>(this DbSet<T> dbSet, Tenant tenant) where T: class, ITenantRelation
        {
            return dbSet.OfTenant(tenant.Id);
        }
        
        public static DbSet<T> OfTenant<T>(this DbSet<T> dbSet, Guid tenantId) where T: class, ITenantRelation
        {
            return (DbSet<T>) dbSet.Where(x => x.TenantId == tenantId);
        }
    }
}