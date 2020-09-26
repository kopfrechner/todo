using System.Collections.Generic;
using todo.dal.Models.Abstractions;

namespace todo.dal.Models
{
    /// <summary>
    /// Collection of <see cref="TodoItem"/>
    /// </summary>
    public class TotoList : TenantEntityWithId
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