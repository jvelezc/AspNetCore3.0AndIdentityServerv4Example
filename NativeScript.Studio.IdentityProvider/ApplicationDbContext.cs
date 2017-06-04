using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NativeScript.Studio.IdentityProvider.Entities;
using NativeScript.Studio.IdentityProvider.AspNetCoreIdentityExtensions;
namespace NativeScriptStudio.EfCore
{
    public class ApplicationDbContext : IdentityDbContext
         <
             ApplicationUser,
             ApplicationRole,
             int,
             ApplicationUserClaim,
             ApplicationUserRole,
             ApplicationUserLogin,
             ApplicationRoleClaim,
             ApplicationUserToken
        >
    {
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }


        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AspNetIdentityTableConfig();
            builder.RemovePluralizingTableNameConvention();
        }
    }

}
