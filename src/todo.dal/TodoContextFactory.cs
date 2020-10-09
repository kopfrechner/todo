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
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
            //optionsBuilder.UseSqlite("Data Source=:memory:"); // simply use an in-memory database
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=todo; Integrated Security=True; MultipleActiveResultSets=False;");
            
            return new TodoDbContext(optionsBuilder.Options, null);
        }
    }
}