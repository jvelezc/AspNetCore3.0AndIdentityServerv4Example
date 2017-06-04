using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NativeScript.Studio.IdentityProvider.Entities;
using NativeScriptStudio.EfCore;
using System.Security.Claims;

namespace NativeScript.Studio.IdentityProvider.AspNetCoreIdentityExtensions
{
    public class ApplicationUserStore : UserStore<
          ApplicationUser,
          ApplicationRole,
          ApplicationDbContext,
          int,
          ApplicationUserClaim,
          ApplicationUserRole,
          ApplicationUserLogin,
          ApplicationUserToken,
          ApplicationRoleClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }

        protected override ApplicationUserClaim CreateUserClaim(ApplicationUser user, Claim claim)
        {
            var userClaim = new ApplicationUserClaim { UserId = user.Id };
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override ApplicationUserLogin CreateUserLogin(ApplicationUser user, UserLoginInfo login)
        {
            return new ApplicationUserLogin
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override ApplicationUserRole CreateUserRole(ApplicationUser user, ApplicationRole role)
        {
            return new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override ApplicationUserToken CreateUserToken(ApplicationUser user, string loginProvider, string name, string value)
        {
            return new ApplicationUserToken
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }
}