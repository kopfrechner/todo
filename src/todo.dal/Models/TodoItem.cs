using System;
using todo.dal.Models;
using todo.dal.Models.Abstractions;

namespace todo.dal
{
    /// <summary>
    /// Describes what to do
    /// </summary>
    public class TodoItem : TenantEntityWithId
    {
        /// <summary>
        /// What needs to be done
        /// </summary>
        public string DoWhat { get; set; }
        
        /// <summary>
        /// More details about it
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// It's done or not
        /// </summary>
        public bool Done { get; set; }
        
        /// <summary>
        /// Navigation property to <see cref="TotoList"/>
        /// </summary>
        public virtual TotoList TotoList { get; set;  }
        
        /// <summary>
        /// Foreign key to TodoList
        /// </summary>
        public Guid TodoListId { get; set; }
    }
}
