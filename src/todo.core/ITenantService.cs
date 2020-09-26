using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Dal.Models;

namespace Todo.Core
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> LoadAllTenantsAsync();
    }
}