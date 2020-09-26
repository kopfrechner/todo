using System;

namespace Todo.Core
{
    public class TodoListDto
    {
        public Guid Id { get; set; }
        
        /// <summary>
        /// Title of the list
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Description of the list
        /// </summary>
        public string Description { get; set; }
    }
}