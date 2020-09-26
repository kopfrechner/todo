using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Todo.Dal
{
    /// <summary>
    /// Create a default db context for design time
    /// </summary>
    /// <remarks>
    /// With this class we can cerate db-migrations, without an actual database
    /// dotnet ef migrations add <MIGRATION-NAME>
    /// </remarks>
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseSqlite("Data Source=:memory:"); // simply use an in-memory database
            
            return new TodoContext(optionsBuilder.Options);
        }
    }
}