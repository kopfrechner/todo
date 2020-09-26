using System;

namespace Todo.Dal.Models.Abstractions
{
    /// <summary>
    /// Entity containing a unique GUID
    /// </summary>
    public interface IEntityWithId
    {
        /// <summary>
        /// The unique global identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}