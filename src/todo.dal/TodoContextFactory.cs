using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace todo.dal
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseSqlite("Data Source=:memory:");

            return new TodoContext(optionsBuilder.Options);
        }
    }
}