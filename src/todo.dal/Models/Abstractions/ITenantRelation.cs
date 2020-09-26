using System;

namespace Todo.Dal.Models.Abstractions
{
    /// <summary>
    /// Entity with tenant relation
    /// </summary>
    public interface ITenantRelation
    {
        /// <summary>
        /// Navigation property to <see cref="Tenant"/>
        /// </summary>
        Tenant Tenant { get; set; }
        
        /// <summary>
        /// Foreign key to <see cref="Tenant"/>
        /// </summary>
        Guid? TenantId { get; set; }
    }
}