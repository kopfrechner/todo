using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Core;
using Todo.Dal;

namespace Todo.Core.Tenant
{
    public class TenantService : ITenantService
    {
        private readonly TodoDbContext _db;

        public TenantService(TodoDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<TenantDto>> LoadAllTenantsAsync()
        {
            return await _db.Tenants.Select(x => new TenantDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}