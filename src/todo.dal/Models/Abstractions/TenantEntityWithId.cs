using System;

namespace Todo.Dal.Models.Abstractions
{
    public abstract class TenantEntityWithId : EntityWithId, ITenantEntityWithId
    {
        public virtual Tenant Tenant { get; set; }
        public Guid? TenantId { get; set; }
    }
}