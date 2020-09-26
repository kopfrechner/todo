using System;

namespace Todo.Core
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        
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
    }
}