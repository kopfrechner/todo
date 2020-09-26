using System;

namespace Todo.Dal.Models.Abstractions
{
    public abstract class EntityWithId : IEntityWithId 
    {
        public Guid Id { get; set; }
    }
}    