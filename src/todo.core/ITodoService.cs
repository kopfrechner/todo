using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core
{
    /// <summary>
    /// Basic functionality to interact with my todos
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Load a list of TotoLists of <paramref name="tenantId"/>
        /// </summary>
        /// <param name="tenantId">Tenant</param>
        /// <returns>A list of todolists</returns>
        Task<IEnumerable<TodoList>> LoadTodoListsAsync(Guid tenantId);
        
        /// <summary>
        /// Load a list of TodoItems of <paramref name="todoListId"/>
        /// </summary>
        /// <param name="tenantId">Tenant</param>
        /// <param name="todoListId">List</param>
        /// <returns>A list of todoItems</returns>
        Task<IEnumerable<TodoItem>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId);
    }
}