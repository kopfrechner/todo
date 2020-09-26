using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _db;

        public TodoService(TodoDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<TodoList>> LoadTodoListsAsync(Guid tenantId)
        {
            return await _db.TodoLists.Where(x => x.TenantId == tenantId).ToListAsync();
        }
        
        public async Task<IEnumerable<TodoItem>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId)
        {
            return await _db.TodoItems.Where(x => x.TenantId == tenantId && x.TodoListId == todoListId).ToListAsync();
        }
    }
}