using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NativeScript.Studio.IdentityProvider.Entities
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole, ApplicationRoleClaim>
    {
       
    }
}