using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Todo.Dal.Models
{
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Tenants where this user lives in
        /// </summary>
        public virtual ICollection<TenantUser> AssignedTenants { get; set; }
    }
    
    public class Role : IdentityRole<Guid>{ }
    public class UserClaim : IdentityUserClaim<Guid> { }
    public class UserRole : IdentityUserRole<Guid> { }
    public class RoleClaim : IdentityRoleClaim<Guid> { }
    public class UserLogin : IdentityUserLogin<Guid> { }
    public class UserToken : IdentityUserToken<Guid> { }
}