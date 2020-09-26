using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core
{
    public class TenantService : ITenantService
    {
        private readonly TodoContext _db;

        public TenantService(TodoContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<Tenant>> LoadAllTenantsAsync()
        {
            return await _db.Tenants.ToListAsync();
        }
    }
}