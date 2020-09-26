using System;

namespace Todo.Dal.Models.Abstractions
{
    public abstract class TenantEntityWithId : ITenantEntityWithId
    {
        public Guid Id { get; set; }
        public Tenant Tenant { get; set; }
        public Guid? TenantId { get; set; }
    }
}