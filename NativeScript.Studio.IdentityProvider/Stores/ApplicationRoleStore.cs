using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NativeScript.Studio.IdentityProvider.Entities;
using NativeScriptStudio.EfCore;
using System.Security.Claims;

namespace NativeScript.Studio.IdentityProvider.Stores
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, int, ApplicationUserRole, ApplicationRoleClaim>
    {
        public ApplicationRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
        protected override ApplicationRoleClaim CreateRoleClaim(ApplicationRole role, Claim claim)
        {
            return new ApplicationRoleClaim { RoleId = role.Id, ClaimType = claim.Type, ClaimValue = claim.Value };
        }
    }
}