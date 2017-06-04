using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NativeScript.Studio.IdentityProvider.Entities
{
    public class ApplicationUser : IdentityUser<int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin>
    {
    }
}