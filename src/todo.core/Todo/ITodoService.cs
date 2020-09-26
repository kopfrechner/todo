using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Core
{
    /// <summary>
    /// Basic functionality to interact with my todos
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Load a list of TodoLists of <paramref name="tenantId"/>
        /// </summary>
        /// <param name="tenantId">Tenant</param>
        /// <returns>A list of todolists</returns>
        Task<IEnumerable<TodoListDto>> LoadTodoListsAsync(Guid tenantId);
        
        /// <summary>
        /// Load a list of TodoItems of <paramref name="todoListId"/>
        /// </summary>
        /// <param name="tenantId">Tenant</param>
        /// <param name="todoListId">List</param>
        /// <returns>A list of todoItems</returns>
        Task<IEnumerable<TodoItemDto>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId);
    }
}