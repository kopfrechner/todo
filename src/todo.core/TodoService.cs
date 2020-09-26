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
        private readonly ITodoDbContext _db;

        public TodoService(ITodoDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<TodoList>> LoadTodoListsAsync(Guid tenantId)
        {
            return await _db.TodoLists.ToListAsync();
        }
        
        public async Task<IEnumerable<TodoItem>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId)
        {
            return await _db.TodoItems.Where(x => x.TodoListId == todoListId).ToListAsync();
        }
    }
}