using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Tenant;

namespace Todo.Core
{
    public interface ITenantService
    {
        Task<IEnumerable<TenantDto>> LoadAllTenantsAsync();
    }
}