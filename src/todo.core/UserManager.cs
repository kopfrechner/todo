using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Todo.Dal;
using Todo.Dal.Models;

namespace Todo.Core
{
    public class UserWithTenantManager<TUser> : UserManager<TUser> where TUser : IdentityUser<Guid>
    {
        private readonly ITodoDbContext _db;

        public UserWithTenantManager(
            IUserStore<TUser> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<TUser> passwordHasher, 
            IEnumerable<IUserValidator<TUser>> userValidators, 
            IEnumerable<IPasswordValidator<TUser>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<TUser>> logger,
            ITodoDbContext db) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _db = db;
        }

        public async Task<IdentityResult> CreateAsync(TUser user, Guid tenantId)
        {
            var tenant = _db.Tenants.FirstOrDefault(x => x.Id == tenantId);
            if (tenant == null)
            {
                throw new ArgumentException("Tenant does not exist", nameof(tenantId));
            }
            
            var identityResult = await base.CreateAsync(user);
            if (!identityResult.Succeeded)
            {
                return identityResult;
            }
            
            await AssignUserToTenant(user, tenantId);

            return identityResult;
        }

        public async Task<IdentityResult> CreateAsync(TUser user, string password, Guid tenantId)
        {
            var tenant = _db.Tenants.FirstOrDefault(x => x.Id == tenantId);
            if (tenant == null)
            {
                throw new ArgumentException("Tenant does not exist", nameof(tenantId));
            }
            
            var identityResult = await base.CreateAsync(user, password);
            if (!identityResult.Succeeded)
            {
                return identityResult;
            }

            await AssignUserToTenant(user, tenantId);

            return identityResult;
        }

        private async Task AssignUserToTenant(TUser user, Guid tenantId)
        {
            await _db.TenantUsers.AddAsync(new TenantUser
            {
                TenantId = tenantId,
                UserId = user.Id
            });
            await _db.SaveChangesAsync();
        }
        
        // TODO care about claims, etc...
        
#pragma warning disable CS0809
        [Obsolete("Tenant is required", true)]
        public override async Task<IdentityResult> CreateAsync(TUser user)
        {
            return await base.CreateAsync(user);
        }
#pragma warning restore CS0809
        
#pragma warning disable CS0809
        [Obsolete("Tenant is required", true)]
        public override async Task<IdentityResult> CreateAsync(TUser user, string password)
        {
            return await base.CreateAsync(user, password);
        }
#pragma warning restore CS0809
        
    }
}