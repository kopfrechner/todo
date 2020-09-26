using System;

namespace todo.dal.Models.Abstractions
{
    /// <summary>
    /// Entity with tenant relation
    /// </summary>
    public interface ITenantRelation
    {
        /// <summary>
        /// Navigation property to <see cref="Tenant"/>
        /// </summary>
        public Tenant Tenant { get; set; }
        
        /// <summary>
        /// Foreign key to <see cref="Tenant"/>
        /// </summary>
        public Guid? TenantId { get; set; }
    }
}