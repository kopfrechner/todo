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
        
        public async Task<IEnumerable<TodoListDto>> LoadTodoListsAsync(Guid tenantId)
        {
            return await _db.Query<TodoList>().Select(x => new TodoListDto
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title
            }).ToListAsync();
        }
        
        public async Task<IEnumerable<TodoItemDto>> LoadTodoItemsAsync(Guid tenantId, Guid todoListId)
        {
            return await _db.Query<TodoItem>().Where(x => x.TodoListId == todoListId).Select(x => new TodoItemDto
            {
                Id = x.Id,
                Description = x.Description,
                Done = x.Done,
                DoWhat = x.DoWhat
            }).ToListAsync();
        }
    }
}