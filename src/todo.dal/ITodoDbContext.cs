
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Todo.Dal
{
    public interface ITodoDbContext
    {
        IQueryable<T> Query<T>() where T : class;
        DbSet<T> Manipulate<T>() where T : class;

        void BeginTransaction();
        void Commit();
        void Rollback();

        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}