using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core.IdentiyCustomization
{
    /// <summary>
    /// Add custom claims to http context when authenticing
    /// </summary>
    public class TenantAwareUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
    {
        private readonly ITodoDbContext _db;

        public TenantAwareUserClaimsPrincipalFactory(
            ITodoDbContext db,
            UserWithTenantManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _db = db;
        }
        
        /// <summary>
        /// Add tenant claim as GroupSid
        /// </summary>
        public override async Task<ClaimsPrincipal> CreateAsync(User user)
        {
            var tenantId = _db.TenantUsers.Where(x => x.UserId == user.Id).Select(x => x.TenantId).FirstOrDefault();
            if (tenantId == null)
            {
                throw new InvalidOperationException("Cannot find tenant and thus cannot add tenant claim.");
            }

            var principal = await base.CreateAsync(user);
            ((ClaimsIdentity) principal.Identity).AddClaim(new Claim(ClaimTypes.GroupSid, tenantId.ToString()));
            return principal;
        }
    }
}