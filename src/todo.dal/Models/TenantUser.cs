using System;
using Todo.Dal.Models.Abstractions;

namespace Todo.Dal.Models
{
    public class TenantUser : TenantEntityWithId
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}