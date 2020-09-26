using System;

namespace todo.dal.Models.Abstractions
{
    public abstract class EntityWithId : IEntityWithId 
    {
        public Guid Id { get; set; }
    }
}    