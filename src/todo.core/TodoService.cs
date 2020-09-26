using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Dal;
using Todo.Dal.Models;

namespace todo.core
{
    public class TodoService
    {
        private readonly TodoContext _db;

        public TodoService(TodoContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<TotoList>> LoadTodoListsAsync(Guid tenantId)
        {
            return await _db.TodoLists.Where(x => x.TenantId == tenantId).ToListAsync();
        }
        
        public async Task<IEnumerable<TodoItem>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId)
        {
            return await _db.TodoItems.Where(x => x.TenantId == tenantId && x.TodoListId == todoListId).ToListAsync();
        }
    }
}