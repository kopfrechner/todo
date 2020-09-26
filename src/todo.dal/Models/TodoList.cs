using System.Collections.Generic;
using Todo.Dal.Models.Abstractions;

namespace Todo.Dal.Models
{
    /// <summary>
    /// Collection of <see cref="TodoItem"/>
    /// </summary>
    public class TodoList : TenantEntityWithId
    {
        /// <summary>
        /// Title of the list
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Description of the list
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Navigation property to items
        /// </summary>
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}